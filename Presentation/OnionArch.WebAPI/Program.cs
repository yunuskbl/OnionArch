using OnionArch.PERSISTENCE.DependencyResolvers;
using OnionArch.APPLICATION.DependencyResolvers;
using OnionArch.INFRASTRUCTURE.DependencyResolvers;
using OnionArch.INFRASTRUCTURE.Configurations;
using OnionArch.WebAPI.Filters;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.AddLoggerConfiguration(builder.Configuration);

builder.Services.AddApplicationMapperService();
builder.Services.AddRepositoryServices();
builder.Services.AddDbContextService();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LoggingFiltersAttribute>();
});
builder.Services.AddManagerService();
builder.Services.AddLoggerService();
builder.Services.AddFluentValidationService();
builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Onion Architecture API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Lütfen JWT tokeninizi Girin"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("http://localhost:5211/swagger/v1/swagger.json","OnionArch.WebAPI v1");
        //c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
