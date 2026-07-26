// Türkçe besin veritabanı. Değerler 100g/100ml içindir (yaklaşık ortalama değerlerdir).
// kcal: kalori, p: protein(g), c: karbonhidrat(g), f: yağ(g)
const FOOD_DB = [
  // Kahvaltılık
  { name: "Haşlanmış Yumurta", cat: "Kahvaltılık", kcal: 155, p: 13, c: 1.1, f: 11 },
  { name: "Sahanda Yumurta", cat: "Kahvaltılık", kcal: 196, p: 13.6, c: 0.9, f: 15.3 },
  { name: "Beyaz Peynir", cat: "Kahvaltılık", kcal: 264, p: 17, c: 2, f: 21 },
  { name: "Kaşar Peyniri", cat: "Kahvaltılık", kcal: 371, p: 25, c: 2.9, f: 29 },
  { name: "Lor Peyniri", cat: "Kahvaltılık", kcal: 98, p: 12, c: 3.4, f: 4.3 },
  { name: "Tereyağı", cat: "Kahvaltılık", kcal: 717, p: 0.9, c: 0.1, f: 81 },
  { name: "Zeytin (Siyah)", cat: "Kahvaltılık", kcal: 115, p: 0.8, c: 6, f: 11 },
  { name: "Zeytin (Yeşil)", cat: "Kahvaltılık", kcal: 145, p: 1, c: 3.8, f: 15 },
  { name: "Bal", cat: "Kahvaltılık", kcal: 304, p: 0.3, c: 82, f: 0 },
  { name: "Reçel", cat: "Kahvaltılık", kcal: 278, p: 0.4, c: 69, f: 0.1 },
  { name: "Tahin", cat: "Kahvaltılık", kcal: 595, p: 17, c: 21, f: 54 },
  { name: "Pekmez", cat: "Kahvaltılık", kcal: 290, p: 0.6, c: 71, f: 0.2 },
  { name: "Sucuk (Kızarmış)", cat: "Kahvaltılık", kcal: 350, p: 20, c: 2, f: 29 },
  { name: "Menemen", cat: "Kahvaltılık", kcal: 130, p: 7, c: 5, f: 9 },

  // Ekmek ve Tahıllar
  { name: "Beyaz Ekmek", cat: "Ekmek/Tahıl", kcal: 265, p: 9, c: 49, f: 3.2 },
  { name: "Tam Buğday Ekmeği", cat: "Ekmek/Tahıl", kcal: 247, p: 13, c: 41, f: 3.4 },
  { name: "Simit", cat: "Ekmek/Tahıl", kcal: 275, p: 8, c: 52, f: 4 },
  { name: "Pirinç Pilavı", cat: "Ekmek/Tahıl", kcal: 130, p: 2.7, c: 28, f: 0.3 },
  { name: "Bulgur Pilavı", cat: "Ekmek/Tahıl", kcal: 118, p: 3.6, c: 25, f: 0.4 },
  { name: "Makarna (Haşlanmış)", cat: "Ekmek/Tahıl", kcal: 158, p: 5.8, c: 31, f: 0.9 },
  { name: "Yulaf Ezmesi", cat: "Ekmek/Tahıl", kcal: 389, p: 17, c: 66, f: 7 },
  { name: "Mısır Gevreği", cat: "Ekmek/Tahıl", kcal: 378, p: 7, c: 84, f: 0.9 },
  { name: "Kinoa (Haşlanmış)", cat: "Ekmek/Tahıl", kcal: 120, p: 4.4, c: 21, f: 1.9 },

  // Süt Ürünleri
  { name: "Süt (Tam Yağlı)", cat: "Süt Ürünleri", kcal: 61, p: 3.2, c: 4.8, f: 3.3 },
  { name: "Süt (Yarım Yağlı)", cat: "Süt Ürünleri", kcal: 46, p: 3.4, c: 5, f: 1.6 },
  { name: "Yoğurt (Tam Yağlı)", cat: "Süt Ürünleri", kcal: 61, p: 3.5, c: 4.7, f: 3.3 },
  { name: "Süzme Yoğurt (Yunan)", cat: "Süt Ürünleri", kcal: 97, p: 9, c: 4, f: 5 },
  { name: "Ayran", cat: "Süt Ürünleri", kcal: 38, p: 1.7, c: 2.5, f: 1.5 },
  { name: "Kefir", cat: "Süt Ürünleri", kcal: 56, p: 3.3, c: 4.5, f: 2 },

  // Et, Tavuk, Balık
  { name: "Tavuk Göğsü (Izgara)", cat: "Et/Tavuk/Balık", kcal: 165, p: 31, c: 0, f: 3.6 },
  { name: "Tavuk But (Derisiz)", cat: "Et/Tavuk/Balık", kcal: 177, p: 24, c: 0, f: 8.5 },
  { name: "Dana Kıyma (Yağsız)", cat: "Et/Tavuk/Balık", kcal: 176, p: 20, c: 0, f: 10 },
  { name: "Dana Bonfile", cat: "Et/Tavuk/Balık", kcal: 187, p: 26, c: 0, f: 8.6 },
  { name: "Kuzu Eti", cat: "Et/Tavuk/Balık", kcal: 294, p: 25, c: 0, f: 21 },
  { name: "Hindi Göğsü", cat: "Et/Tavuk/Balık", kcal: 135, p: 30, c: 0, f: 1 },
  { name: "Somon (Izgara)", cat: "Et/Tavuk/Balık", kcal: 208, p: 20, c: 0, f: 13 },
  { name: "Ton Balığı (Suda)", cat: "Et/Tavuk/Balık", kcal: 116, p: 26, c: 0, f: 0.8 },
  { name: "Levrek", cat: "Et/Tavuk/Balık", kcal: 97, p: 18, c: 0, f: 2.5 },
  { name: "Hamsi (Kızarmış)", cat: "Et/Tavuk/Balık", kcal: 210, p: 20, c: 4, f: 13 },
  { name: "Yumurta Akı", cat: "Et/Tavuk/Balık", kcal: 52, p: 11, c: 0.7, f: 0.2 },

  // Baklagiller
  { name: "Nohut (Haşlanmış)", cat: "Baklagiller", kcal: 164, p: 9, c: 27, f: 2.6 },
  { name: "Kuru Fasulye (Haşlanmış)", cat: "Baklagiller", kcal: 127, p: 9, c: 23, f: 0.5 },
  { name: "Mercimek (Haşlanmış)", cat: "Baklagiller", kcal: 116, p: 9, c: 20, f: 0.4 },
  { name: "Mercimek Çorbası", cat: "Baklagiller", kcal: 80, p: 4.5, c: 12, f: 1.8 },
  { name: "Barbunya", cat: "Baklagiller", kcal: 130, p: 8.7, c: 23, f: 0.5 },

  // Sebzeler
  { name: "Domates", cat: "Sebze", kcal: 18, p: 0.9, c: 3.9, f: 0.2 },
  { name: "Salatalık", cat: "Sebze", kcal: 15, p: 0.7, c: 3.6, f: 0.1 },
  { name: "Marul", cat: "Sebze", kcal: 15, p: 1.4, c: 2.9, f: 0.2 },
  { name: "Biber (Yeşil)", cat: "Sebze", kcal: 20, p: 0.9, c: 4.6, f: 0.2 },
  { name: "Patates (Haşlanmış)", cat: "Sebze", kcal: 87, p: 1.9, c: 20, f: 0.1 },
  { name: "Patates Kızartması", cat: "Sebze", kcal: 312, p: 3.4, c: 41, f: 15 },
  { name: "Havuç", cat: "Sebze", kcal: 41, p: 0.9, c: 10, f: 0.2 },
  { name: "Soğan", cat: "Sebze", kcal: 40, p: 1.1, c: 9.3, f: 0.1 },
  { name: "Brokoli", cat: "Sebze", kcal: 34, p: 2.8, c: 7, f: 0.4 },
  { name: "Ispanak", cat: "Sebze", kcal: 23, p: 2.9, c: 3.6, f: 0.4 },
  { name: "Kabak", cat: "Sebze", kcal: 17, p: 1.2, c: 3.1, f: 0.3 },
  { name: "Patlıcan", cat: "Sebze", kcal: 25, p: 1, c: 6, f: 0.2 },
  { name: "Salata (Karışık, Zeytinyağlı)", cat: "Sebze", kcal: 70, p: 1.2, c: 5, f: 5 },
  { name: "Sarımsak", cat: "Sebze", kcal: 149, p: 6.4, c: 33, f: 0.5 },

  // Meyveler
  { name: "Elma", cat: "Meyve", kcal: 52, p: 0.3, c: 14, f: 0.2 },
  { name: "Muz", cat: "Meyve", kcal: 89, p: 1.1, c: 23, f: 0.3 },
  { name: "Portakal", cat: "Meyve", kcal: 47, p: 0.9, c: 12, f: 0.1 },
  { name: "Karpuz", cat: "Meyve", kcal: 30, p: 0.6, c: 7.6, f: 0.2 },
  { name: "Çilek", cat: "Meyve", kcal: 32, p: 0.7, c: 7.7, f: 0.3 },
  { name: "Üzüm", cat: "Meyve", kcal: 69, p: 0.7, c: 18, f: 0.2 },
  { name: "Kayısı", cat: "Meyve", kcal: 48, p: 1.4, c: 11, f: 0.4 },
  { name: "Şeftali", cat: "Meyve", kcal: 39, p: 0.9, c: 9.5, f: 0.3 },
  { name: "Armut", cat: "Meyve", kcal: 57, p: 0.4, c: 15, f: 0.1 },
  { name: "Kiraz", cat: "Meyve", kcal: 63, p: 1.1, c: 16, f: 0.2 },
  { name: "İncir", cat: "Meyve", kcal: 74, p: 0.8, c: 19, f: 0.3 },
  { name: "Nar", cat: "Meyve", kcal: 83, p: 1.7, c: 19, f: 1.2 },
  { name: "Avokado", cat: "Meyve", kcal: 160, p: 2, c: 8.5, f: 15 },
  { name: "Kavun", cat: "Meyve", kcal: 34, p: 0.8, c: 8.2, f: 0.2 },

  // Kuruyemiş
  { name: "Ceviz", cat: "Kuruyemiş", kcal: 654, p: 15, c: 14, f: 65 },
  { name: "Badem", cat: "Kuruyemiş", kcal: 579, p: 21, c: 22, f: 50 },
  { name: "Fıstık (Yer Fıstığı)", cat: "Kuruyemiş", kcal: 567, p: 26, c: 16, f: 49 },
  { name: "Antep Fıstığı", cat: "Kuruyemiş", kcal: 560, p: 20, c: 28, f: 45 },
  { name: "Fındık", cat: "Kuruyemiş", kcal: 628, p: 15, c: 17, f: 61 },
  { name: "Kuru Üzüm", cat: "Kuruyemiş", kcal: 299, p: 3.1, c: 79, f: 0.5 },
  { name: "Kuru Kayısı", cat: "Kuruyemiş", kcal: 241, p: 3.4, c: 63, f: 0.5 },

  // Atıştırmalık / Tatlı
  { name: "Çikolata (Sütlü)", cat: "Atıştırmalık", kcal: 535, p: 7.6, c: 59, f: 30 },
  { name: "Bisküvi", cat: "Atıştırmalık", kcal: 450, p: 6, c: 68, f: 17 },
  { name: "Cips (Patates)", cat: "Atıştırmalık", kcal: 536, p: 6.6, c: 53, f: 34 },
  { name: "Baklava", cat: "Atıştırmalık", kcal: 380, p: 6, c: 45, f: 20 },
  { name: "Sütlaç", cat: "Atıştırmalık", kcal: 130, p: 3.5, c: 20, f: 4 },
  { name: "Künefe", cat: "Atıştırmalık", kcal: 320, p: 6, c: 38, f: 16 },
  { name: "Dondurma", cat: "Atıştırmalık", kcal: 207, p: 3.5, c: 24, f: 11 },
  { name: "Kek", cat: "Atıştırmalık", kcal: 371, p: 5, c: 55, f: 15 },
  { name: "Gofret", cat: "Atıştırmalık", kcal: 490, p: 5, c: 60, f: 25 },

  // İçecekler
  { name: "Su", cat: "İçecek", kcal: 0, p: 0, c: 0, f: 0 },
  { name: "Kola", cat: "İçecek", kcal: 42, p: 0, c: 10.6, f: 0 },
  { name: "Meyve Suyu (Şekerli)", cat: "İçecek", kcal: 45, p: 0.3, c: 11, f: 0.1 },
  { name: "Çay (Şekersiz)", cat: "İçecek", kcal: 1, p: 0, c: 0.3, f: 0 },
  { name: "Türk Kahvesi (Şekersiz)", cat: "İçecek", kcal: 2, p: 0.1, c: 0.4, f: 0 },
  { name: "Latte (Tam Yağlı Süt)", cat: "İçecek", kcal: 61, p: 3.2, c: 4.8, f: 3.3 },
  { name: "Şalgam Suyu", cat: "İçecek", kcal: 15, p: 0.3, c: 3.2, f: 0.1 },
  { name: "Enerji İçeceği", cat: "İçecek", kcal: 45, p: 0, c: 11, f: 0 },
  { name: "Bira", cat: "İçecek", kcal: 43, p: 0.5, c: 3.6, f: 0 },

  // Yağlar
  { name: "Zeytinyağı", cat: "Yağ", kcal: 884, p: 0, c: 0, f: 100 },
  { name: "Ayçiçek Yağı", cat: "Yağ", kcal: 884, p: 0, c: 0, f: 100 },
  { name: "Margarin", cat: "Yağ", kcal: 717, p: 0.2, c: 0.9, f: 80 },

  // Hazır / Fast Food
  { name: "Hamburger (Köfteli)", cat: "Hazır Yemek", kcal: 295, p: 17, c: 24, f: 14 },
  { name: "Pizza (Karışık)", cat: "Hazır Yemek", kcal: 266, p: 11, c: 33, f: 10 },
  { name: "Döner (Tavuk)", cat: "Hazır Yemek", kcal: 215, p: 18, c: 12, f: 11 },
  { name: "Döner (Et)", cat: "Hazır Yemek", kcal: 260, p: 19, c: 10, f: 16 },
  { name: "Lahmacun", cat: "Hazır Yemek", kcal: 235, p: 10, c: 34, f: 7 },
  { name: "Pide (Kaşarlı)", cat: "Hazır Yemek", kcal: 275, p: 11, c: 38, f: 9 },
  { name: "Mantı", cat: "Hazır Yemek", kcal: 210, p: 8, c: 28, f: 7 },
  { name: "Çorba (Ezogelin)", cat: "Hazır Yemek", kcal: 65, p: 3, c: 10, f: 1.5 },
  { name: "Izgara Köfte", cat: "Hazır Yemek", kcal: 250, p: 22, c: 2, f: 17 },
  { name: "Kuru Fasulye + Pilav (Porsiyon)", cat: "Hazır Yemek", kcal: 210, p: 7, c: 33, f: 5 },
];
