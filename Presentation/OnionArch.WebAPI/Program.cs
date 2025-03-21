using OnionArch.PERSISTENCE.DependencyResolvers;
using OnionArch.APPLICATION.DependencyResolvers;
using OnionArch.INFRASTRUCTURE.DependencyResolvers;
using OnionArch.INFRASTRUCTURE.Configurations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.AddLoggerConfiguration(builder.Configuration);

builder.Services.AddApplicationMapperService(); 
builder.Services.AddRepositoryServices();
builder.Services.AddDbContextService();
builder.Services.AddControllers();
builder.Services.AddManagerService();
builder.Services.AddLoggerService();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
