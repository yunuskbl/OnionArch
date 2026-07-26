// Öğün Takip ve Besin Değeri Uygulaması - localStorage tabanlı, sunucu gerektirmez.

const STORAGE_KEYS = {
  logs: "mt_logs",
  customFoods: "mt_custom_foods",
  settings: "mt_settings",
};

const MEAL_TYPES = [
  { id: "breakfast", label: "Kahvaltı", ic: "🍳" },
  { id: "lunch", label: "Öğle Yemeği", ic: "🍲" },
  { id: "dinner", label: "Akşam Yemeği", ic: "🍽️" },
  { id: "snack", label: "Ara Öğün", ic: "🍎" },
];

const DEFAULT_SETTINGS = {
  calorieGoal: 2000,
  proteinGoal: 100,
  carbGoal: 250,
  fatGoal: 65,
  theme: "auto",
  profile: { gender: "female", age: 30, height: 165, weight: 65, activity: 1.375, goalType: "maintain" },
};

function turkishNormalize(str) {
  return str
    .toLocaleLowerCase("tr-TR")
    .replace(/ı/g, "i").replace(/İ/g, "i")
    .replace(/ş/g, "s").replace(/ğ/g, "g")
    .replace(/ü/g, "u").replace(/ö/g, "o").replace(/ç/g, "c");
}

function todayStr() {
  return dateToStr(new Date());
}
function dateToStr(d) {
  const y = d.getFullYear();
  const m = String(d.getMonth() + 1).padStart(2, "0");
  const day = String(d.getDate()).padStart(2, "0");
  return `${y}-${m}-${day}`;
}
function strToDate(s) {
  const [y, m, d] = s.split("-").map(Number);
  return new Date(y, m - 1, d);
}
function formatDateLabel(s) {
  const d = strToDate(s);
  const today = todayStr();
  const yStr = dateToStr(new Date(Date.now() - 86400000));
  let prefix = "";
  if (s === today) prefix = "Bugün · ";
  else if (s === yStr) prefix = "Dün · ";
  const opts = { day: "numeric", month: "long", year: "numeric" };
  return prefix + d.toLocaleDateString("tr-TR", opts);
}
function weekdayLabel(s) {
  return strToDate(s).toLocaleDateString("tr-TR", { weekday: "long" });
}

function loadJSON(key, fallback) {
  try {
    const raw = localStorage.getItem(key);
    if (!raw) return fallback;
    return JSON.parse(raw);
  } catch (e) {
    return fallback;
  }
}
function saveJSON(key, val) {
  localStorage.setItem(key, JSON.stringify(val));
}

const state = {
  currentDate: todayStr(),
  activeTab: "today",
  logs: loadJSON(STORAGE_KEYS.logs, []),
  customFoods: loadJSON(STORAGE_KEYS.customFoods, []),
  settings: Object.assign({}, DEFAULT_SETTINGS, loadJSON(STORAGE_KEYS.settings, {})),
  foodSearch: "",
  foodCat: "Tümü",
  addSheet: { open: false, food: null, mealType: "breakfast", grams: 100, mode: "food" },
};

function allFoods() {
  return FOOD_DB.concat(state.customFoods);
}

function persistLogs() { saveJSON(STORAGE_KEYS.logs, state.logs); }
function persistCustomFoods() { saveJSON(STORAGE_KEYS.customFoods, state.customFoods); }
function persistSettings() { saveJSON(STORAGE_KEYS.settings, state.settings); }

function logsForDate(dateStr) {
  return state.logs.filter((l) => l.date === dateStr);
}

function round1(n) { return Math.round(n * 10) / 10; }

function computeMacros(food, grams) {
  const ratio = grams / 100;
  return {
    kcal: Math.round(food.kcal * ratio),
    p: round1(food.p * ratio),
    c: round1(food.c * ratio),
    f: round1(food.f * ratio),
  };
}

function applyTheme() {
  const root = document.documentElement;
  if (state.settings.theme === "dark") root.setAttribute("data-theme", "dark");
  else if (state.settings.theme === "light") root.setAttribute("data-theme", "light");
  else root.removeAttribute("data-theme");
}

// ---------- Rendering ----------

function render() {
  document.querySelectorAll(".view").forEach((v) => v.classList.remove("active"));
  document.getElementById(`view-${state.activeTab}`).classList.add("active");
  document.querySelectorAll("nav .tab").forEach((t) => {
    t.classList.toggle("active", t.dataset.tab === state.activeTab);
  });

  if (state.activeTab === "today") renderToday();
  if (state.activeTab === "foods") renderFoods();
  if (state.activeTab === "history") renderHistory();
  if (state.activeTab === "settings") renderSettings();
}

function renderToday() {
  document.getElementById("date-label-text").textContent = formatDateLabel(state.currentDate);
  document.getElementById("date-sub").textContent = weekdayLabel(state.currentDate);

  const dayLogs = logsForDate(state.currentDate);
  const totals = dayLogs.reduce(
    (acc, l) => {
      acc.kcal += l.kcal; acc.p += l.p; acc.c += l.c; acc.f += l.f;
      return acc;
    },
    { kcal: 0, p: 0, c: 0, f: 0 }
  );

  const goal = state.settings.calorieGoal || 2000;
  const pct = Math.min(100, Math.round((totals.kcal / goal) * 100)) || 0;
  document.getElementById("kcal-ring").style.setProperty("--pct", pct);
  document.getElementById("kcal-num").innerHTML = `${totals.kcal}<small>/ ${goal} kcal</small>`;

  const remaining = goal - totals.kcal;
  document.getElementById("kcal-remaining").innerHTML =
    remaining >= 0
      ? `<b>${remaining}</b> kcal kaldı`
      : `<b style="color:var(--danger)">${Math.abs(remaining)}</b> kcal aşıldı`;

  setMacroBar("protein", totals.p, state.settings.proteinGoal);
  setMacroBar("carb", totals.c, state.settings.carbGoal);
  setMacroBar("fat", totals.f, state.settings.fatGoal);

  MEAL_TYPES.forEach((mt) => {
    const entries = dayLogs.filter((l) => l.mealType === mt.id);
    const sum = entries.reduce((s, e) => s + e.kcal, 0);
    const listEl = document.getElementById(`entries-${mt.id}`);
    document.getElementById(`kcalsum-${mt.id}`).textContent = entries.length ? `${sum} kcal` : "";
    if (!entries.length) {
      listEl.innerHTML = `<div class="empty-hint">Henüz bir şey eklenmedi.</div>`;
      return;
    }
    listEl.innerHTML = entries
      .map(
        (e) => `
      <div class="entry">
        <div class="info">
          <div class="name">${escapeHtml(e.name)}</div>
          <div class="meta">${e.grams}g · P${e.p} K${e.c} Y${e.f}</div>
        </div>
        <div class="kcal">${e.kcal} kcal</div>
        <button class="del" data-log-id="${e.id}">✕</button>
      </div>`
      )
      .join("");
  });
}

function setMacroBar(kind, val, goal) {
  const g = goal || 1;
  const pct = Math.min(100, Math.round((val / g) * 100)) || 0;
  document.getElementById(`bar-${kind}`).style.width = pct + "%";
  document.getElementById(`val-${kind}`).textContent = `${round1(val)} / ${g} g`;
}

function escapeHtml(s) {
  const d = document.createElement("div");
  d.textContent = s;
  return d.innerHTML;
}

function renderFoods() {
  const cats = ["Tümü", ...Array.from(new Set(allFoods().map((f) => f.cat)))];
  const chipsEl = document.getElementById("cat-chips");
  chipsEl.innerHTML = cats
    .map((c) => `<button class="chip ${c === state.foodCat ? "active" : ""}" data-cat="${escapeHtml(c)}">${escapeHtml(c)}</button>`)
    .join("");

  const q = turkishNormalize(state.foodSearch.trim());
  const list = allFoods().filter((f) => {
    const matchCat = state.foodCat === "Tümü" || f.cat === state.foodCat;
    const matchQ = !q || turkishNormalize(f.name).includes(q);
    return matchCat && matchQ;
  });

  const listEl = document.getElementById("food-list");
  if (!list.length) {
    listEl.innerHTML = `<div class="empty-hint">Sonuç bulunamadı. "Özel Besin Ekle" ile kendi besinini ekleyebilirsin.</div>`;
    return;
  }
  listEl.innerHTML = list
    .map(
      (f, idx) => `
    <div class="food-row" data-food-name="${escapeHtml(f.name)}">
      <div>
        <div class="fname">${escapeHtml(f.name)}</div>
        <div class="fmeta">${f.cat} · P${f.p} K${f.c} Y${f.f} /100g</div>
      </div>
      <div class="fkcal">${f.kcal} kcal</div>
    </div>`
    )
    .join("");
}

function renderHistory() {
  const byDate = {};
  state.logs.forEach((l) => {
    byDate[l.date] = byDate[l.date] || { kcal: 0, p: 0, c: 0, f: 0 };
    byDate[l.date].kcal += l.kcal;
    byDate[l.date].p += l.p;
    byDate[l.date].c += l.c;
    byDate[l.date].f += l.f;
  });
  const dates = Object.keys(byDate).sort((a, b) => (a < b ? 1 : -1));
  const el = document.getElementById("history-list");
  if (!dates.length) {
    el.innerHTML = `<div class="empty-hint">Henüz geçmiş kaydı yok.</div>`;
    return;
  }
  el.innerHTML = dates
    .map((d) => {
      const t = byDate[d];
      return `<div class="hist-row" data-date="${d}">
        <div>
          <div class="hdate">${formatDateLabel(d)}</div>
          <div class="hsub">P${Math.round(t.p)} · K${Math.round(t.c)} · Y${Math.round(t.f)}</div>
        </div>
        <div class="hkcal">${t.kcal} kcal</div>
      </div>`;
    })
    .join("");
}

function renderSettings() {
  const s = state.settings;
  document.getElementById("set-calorie").value = s.calorieGoal;
  document.getElementById("set-protein").value = s.proteinGoal;
  document.getElementById("set-carb").value = s.carbGoal;
  document.getElementById("set-fat").value = s.fatGoal;
  document.getElementById("set-gender").value = s.profile.gender;
  document.getElementById("set-age").value = s.profile.age;
  document.getElementById("set-height").value = s.profile.height;
  document.getElementById("set-weight").value = s.profile.weight;
  document.getElementById("set-activity").value = s.profile.activity;
  document.getElementById("set-goaltype").value = s.profile.goalType;
  document.querySelectorAll(".theme-chip").forEach((c) => {
    c.classList.toggle("active", c.dataset.theme === s.theme);
  });
}

// ---------- Add-food sheet ----------

function openAddSheet(mealType, food) {
  state.addSheet = { open: true, food: food || null, mealType, grams: 100, mode: food ? "food" : "quick" };
  document.getElementById("sheet-backdrop").classList.add("open");
  document.getElementById("add-sheet").classList.add("open");
  document.getElementById("quick-name").value = "";
  document.getElementById("quick-kcal").value = "";
  document.getElementById("quick-p").value = "";
  document.getElementById("quick-c").value = "";
  document.getElementById("quick-f").value = "";
  updateMealTabsUI();
  updateAddSheetMode();
  updateAddSheetPreview();
}

function closeAddSheet() {
  state.addSheet.open = false;
  document.getElementById("sheet-backdrop").classList.remove("open");
  document.getElementById("add-sheet").classList.remove("open");
}

function updateMealTabsUI() {
  document.querySelectorAll("#meal-tabs button").forEach((b) => {
    b.classList.toggle("active", b.dataset.meal === state.addSheet.mealType);
  });
}

function updateAddSheetMode() {
  const isFood = state.addSheet.mode === "food";
  document.getElementById("food-mode-block").classList.toggle("hidden", !isFood);
  document.getElementById("quick-mode-block").classList.toggle("hidden", isFood);
  document.querySelectorAll("#form-tabs button").forEach((b) => {
    b.classList.toggle("active", b.dataset.mode === state.addSheet.mode);
  });
  const food = state.addSheet.food;
  document.getElementById("sheet-title").textContent = isFood
    ? food
      ? food.name
      : "Besin Seç"
    : "Hızlı Ekle (Kalori)";
}

function updateAddSheetPreview() {
  const food = state.addSheet.food;
  if (!food) {
    document.getElementById("preview-macros").classList.add("hidden");
    return;
  }
  const grams = Number(document.getElementById("grams-input").value) || 0;
  const m = computeMacros(food, grams);
  document.getElementById("preview-macros").classList.remove("hidden");
  document.getElementById("pv-kcal").textContent = m.kcal;
  document.getElementById("pv-p").textContent = m.p + "g";
  document.getElementById("pv-c").textContent = m.c + "g";
  document.getElementById("pv-f").textContent = m.f + "g";
}

function confirmAdd() {
  const { mealType, mode } = state.addSheet;
  let entry;
  if (mode === "food") {
    const food = state.addSheet.food;
    if (!food) return showToast("Önce bir besin seç");
    const grams = Number(document.getElementById("grams-input").value);
    if (!grams || grams <= 0) return showToast("Geçerli bir miktar gir");
    const m = computeMacros(food, grams);
    entry = { id: cryptoId(), date: state.currentDate, mealType, name: food.name, grams, kcal: m.kcal, p: m.p, c: m.c, f: m.f };
  } else {
    const name = document.getElementById("quick-name").value.trim() || "Hızlı Kayıt";
    const kcal = Number(document.getElementById("quick-kcal").value);
    if (!kcal || kcal <= 0) return showToast("Kalori gir");
    const p = Number(document.getElementById("quick-p").value) || 0;
    const c = Number(document.getElementById("quick-c").value) || 0;
    const f = Number(document.getElementById("quick-f").value) || 0;
    entry = { id: cryptoId(), date: state.currentDate, mealType, name, grams: null, kcal, p, c, f };
  }
  state.logs.push(entry);
  persistLogs();
  closeAddSheet();
  render();
  showToast("Eklendi ✓");
}

function cryptoId() {
  return "id_" + Date.now().toString(36) + Math.random().toString(36).slice(2, 8);
}

function showToast(msg) {
  const t = document.getElementById("toast");
  t.textContent = msg;
  t.classList.add("show");
  clearTimeout(showToast._timer);
  showToast._timer = setTimeout(() => t.classList.remove("show"), 1800);
}

// ---------- Custom food sheet ----------

function openCustomFoodSheet() {
  document.getElementById("cf-name").value = "";
  document.getElementById("cf-kcal").value = "";
  document.getElementById("cf-p").value = "";
  document.getElementById("cf-c").value = "";
  document.getElementById("cf-f").value = "";
  document.getElementById("cf-cat").value = "";
  document.getElementById("sheet-backdrop").classList.add("open");
  document.getElementById("custom-food-sheet").classList.add("open");
}
function closeCustomFoodSheet() {
  document.getElementById("sheet-backdrop").classList.remove("open");
  document.getElementById("custom-food-sheet").classList.remove("open");
}
function saveCustomFood() {
  const name = document.getElementById("cf-name").value.trim();
  const kcal = Number(document.getElementById("cf-kcal").value);
  if (!name || !kcal) return showToast("İsim ve kalori zorunlu");
  const food = {
    name,
    cat: document.getElementById("cf-cat").value.trim() || "Özel",
    kcal,
    p: Number(document.getElementById("cf-p").value) || 0,
    c: Number(document.getElementById("cf-c").value) || 0,
    f: Number(document.getElementById("cf-f").value) || 0,
  };
  state.customFoods.push(food);
  persistCustomFoods();
  closeCustomFoodSheet();
  renderFoods();
  showToast("Besin eklendi ✓");
}

// ---------- BMR / goal calculator ----------

function calcSuggestedGoals() {
  const p = state.settings.profile;
  const bmr =
    p.gender === "male"
      ? 10 * p.weight + 6.25 * p.height - 5 * p.age + 5
      : 10 * p.weight + 6.25 * p.height - 5 * p.age - 161;
  let tdee = bmr * Number(p.activity);
  if (p.goalType === "lose") tdee -= 500;
  if (p.goalType === "gain") tdee += 400;
  tdee = Math.max(1200, Math.round(tdee));

  const proteinG = Math.round(p.weight * 1.8);
  const fatKcal = tdee * 0.27;
  const fatG = Math.round(fatKcal / 9);
  const proteinKcal = proteinG * 4;
  const carbKcal = Math.max(0, tdee - fatKcal - proteinKcal);
  const carbG = Math.round(carbKcal / 4);

  document.getElementById("set-calorie").value = tdee;
  document.getElementById("set-protein").value = proteinG;
  document.getElementById("set-carb").value = carbG;
  document.getElementById("set-fat").value = fatG;
  showToast("Hedefler hesaplandı, kaydetmeyi unutma");
}

// ---------- Export / Import ----------

function exportData() {
  const data = {
    logs: state.logs,
    customFoods: state.customFoods,
    settings: state.settings,
    exportedAt: new Date().toISOString(),
  };
  const blob = new Blob([JSON.stringify(data, null, 2)], { type: "application/json" });
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");
  a.href = url;
  a.download = `ogun-takip-yedek-${todayStr()}.json`;
  a.click();
  URL.revokeObjectURL(url);
}

function importData(file) {
  const reader = new FileReader();
  reader.onload = () => {
    try {
      const data = JSON.parse(reader.result);
      if (data.logs) state.logs = data.logs;
      if (data.customFoods) state.customFoods = data.customFoods;
      if (data.settings) state.settings = Object.assign({}, DEFAULT_SETTINGS, data.settings);
      persistLogs();
      persistCustomFoods();
      persistSettings();
      applyTheme();
      render();
      showToast("Veriler içe aktarıldı ✓");
    } catch (e) {
      showToast("Dosya okunamadı");
    }
  };
  reader.readAsText(file);
}

function clearAllData() {
  if (!confirm("Tüm veriler silinecek. Emin misin?")) return;
  state.logs = [];
  state.customFoods = [];
  state.settings = Object.assign({}, DEFAULT_SETTINGS);
  persistLogs();
  persistCustomFoods();
  persistSettings();
  applyTheme();
  render();
  showToast("Tüm veriler silindi");
}

// ---------- Event wiring ----------

function init() {
  applyTheme();
  buildMealSections();
  buildMealTabs();

  document.querySelectorAll("nav .tab").forEach((btn) => {
    btn.addEventListener("click", () => {
      state.activeTab = btn.dataset.tab;
      render();
    });
  });

  document.getElementById("date-prev").addEventListener("click", () => {
    const d = strToDate(state.currentDate);
    d.setDate(d.getDate() - 1);
    state.currentDate = dateToStr(d);
    renderToday();
  });
  document.getElementById("date-next").addEventListener("click", () => {
    const d = strToDate(state.currentDate);
    d.setDate(d.getDate() + 1);
    state.currentDate = dateToStr(d);
    renderToday();
  });
  document.getElementById("date-today-btn").addEventListener("click", () => {
    state.currentDate = todayStr();
    renderToday();
  });

  document.getElementById("view-today").addEventListener("click", (e) => {
    const addBtn = e.target.closest("[data-add-meal]");
    if (addBtn) return openAddSheet(addBtn.dataset.addMeal, null);
    const delBtn = e.target.closest("[data-log-id]");
    if (delBtn) {
      state.logs = state.logs.filter((l) => l.id !== delBtn.dataset.logId);
      persistLogs();
      renderToday();
    }
  });

  // Foods tab
  document.getElementById("food-search").addEventListener("input", (e) => {
    state.foodSearch = e.target.value;
    renderFoods();
  });
  document.getElementById("cat-chips").addEventListener("click", (e) => {
    const chip = e.target.closest(".chip");
    if (!chip) return;
    state.foodCat = chip.dataset.cat;
    renderFoods();
  });
  document.getElementById("food-list").addEventListener("click", (e) => {
    const row = e.target.closest(".food-row");
    if (!row) return;
    const food = allFoods().find((f) => f.name === row.dataset.foodName);
    if (!food) return;
    state.addSheet.mealType = state.addSheet.mealType || "breakfast";
    openAddSheet(state.addSheet.mealType || "breakfast", food);
  });
  document.getElementById("add-custom-food-btn").addEventListener("click", openCustomFoodSheet);

  // History
  document.getElementById("history-list").addEventListener("click", (e) => {
    const row = e.target.closest(".hist-row");
    if (!row) return;
    state.currentDate = row.dataset.date;
    state.activeTab = "today";
    render();
  });

  // Add sheet
  document.getElementById("sheet-backdrop").addEventListener("click", () => {
    closeAddSheet();
    closeCustomFoodSheet();
  });
  document.getElementById("sheet-close").addEventListener("click", closeAddSheet);
  document.getElementById("meal-tabs").addEventListener("click", (e) => {
    const b = e.target.closest("button");
    if (!b) return;
    state.addSheet.mealType = b.dataset.meal;
    updateMealTabsUI();
  });
  document.getElementById("form-tabs").addEventListener("click", (e) => {
    const b = e.target.closest("button");
    if (!b) return;
    state.addSheet.mode = b.dataset.mode;
    updateAddSheetMode();
  });
  document.getElementById("grams-input").addEventListener("input", updateAddSheetPreview);
  document.querySelectorAll(".preset-grams button").forEach((b) => {
    b.addEventListener("click", () => {
      document.getElementById("grams-input").value = b.dataset.g;
      updateAddSheetPreview();
    });
  });
  document.getElementById("grams-minus").addEventListener("click", () => {
    const el = document.getElementById("grams-input");
    el.value = Math.max(0, Number(el.value) - 10);
    updateAddSheetPreview();
  });
  document.getElementById("grams-plus").addEventListener("click", () => {
    const el = document.getElementById("grams-input");
    el.value = Number(el.value) + 10;
    updateAddSheetPreview();
  });
  document.getElementById("confirm-add-btn").addEventListener("click", confirmAdd);

  // Custom food sheet
  document.getElementById("cf-sheet-close").addEventListener("click", closeCustomFoodSheet);
  document.getElementById("cf-save-btn").addEventListener("click", saveCustomFood);

  // Settings
  document.getElementById("settings-save-btn").addEventListener("click", () => {
    state.settings.calorieGoal = Number(document.getElementById("set-calorie").value) || DEFAULT_SETTINGS.calorieGoal;
    state.settings.proteinGoal = Number(document.getElementById("set-protein").value) || DEFAULT_SETTINGS.proteinGoal;
    state.settings.carbGoal = Number(document.getElementById("set-carb").value) || DEFAULT_SETTINGS.carbGoal;
    state.settings.fatGoal = Number(document.getElementById("set-fat").value) || DEFAULT_SETTINGS.fatGoal;
    state.settings.profile = {
      gender: document.getElementById("set-gender").value,
      age: Number(document.getElementById("set-age").value) || 30,
      height: Number(document.getElementById("set-height").value) || 165,
      weight: Number(document.getElementById("set-weight").value) || 65,
      activity: Number(document.getElementById("set-activity").value),
      goalType: document.getElementById("set-goaltype").value,
    };
    persistSettings();
    showToast("Ayarlar kaydedildi ✓");
    render();
  });
  document.getElementById("calc-goal-btn").addEventListener("click", () => {
    state.settings.profile = {
      gender: document.getElementById("set-gender").value,
      age: Number(document.getElementById("set-age").value) || 30,
      height: Number(document.getElementById("set-height").value) || 165,
      weight: Number(document.getElementById("set-weight").value) || 65,
      activity: Number(document.getElementById("set-activity").value),
      goalType: document.getElementById("set-goaltype").value,
    };
    calcSuggestedGoals();
  });
  document.querySelectorAll(".theme-chip").forEach((chip) => {
    chip.addEventListener("click", () => {
      state.settings.theme = chip.dataset.theme;
      persistSettings();
      applyTheme();
      renderSettings();
    });
  });
  document.getElementById("export-btn").addEventListener("click", exportData);
  document.getElementById("import-input").addEventListener("change", (e) => {
    if (e.target.files[0]) importData(e.target.files[0]);
    e.target.value = "";
  });
  document.getElementById("clear-data-btn").addEventListener("click", clearAllData);

  render();

  if ("serviceWorker" in navigator && (location.protocol === "https:" || location.hostname === "localhost")) {
    navigator.serviceWorker.register("sw.js").catch(() => {});
  }
}

function buildMealSections() {
  const container = document.getElementById("meal-sections");
  container.innerHTML = MEAL_TYPES.map(
    (mt) => `
    <div class="section-title">
      <h2>${mt.ic} ${mt.label} <span class="kcal-sum" id="kcalsum-${mt.id}"></span></h2>
      <button class="add-mini" data-add-meal="${mt.id}">+</button>
    </div>
    <div class="card" id="entries-${mt.id}"></div>
  `
  ).join("");
}

function buildMealTabs() {
  document.getElementById("meal-tabs").innerHTML = MEAL_TYPES.map(
    (mt) => `<button data-meal="${mt.id}">${mt.ic} ${mt.label}</button>`
  ).join("");
}

document.addEventListener("DOMContentLoaded", init);
