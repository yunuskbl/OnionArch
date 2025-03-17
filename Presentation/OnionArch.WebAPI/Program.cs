using OnionArch.PERSISTENCE.DependencyResolvers;
using OnionArch.APPLICATION.DependencyResolvers;
using OnionArch.INFRASTRUCTURE.DependencyResolvers;
<<<<<<< HEAD
using OnionArch.WebAPI.Middlewares;
=======
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApplicationMapperService(); 
builder.Services.AddRepositoryServices();
builder.Services.AddDbContextService();
builder.Services.AddControllers();
builder.Services.AddManagerService();
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

<<<<<<< HEAD
app.UseMiddleware<ExceptionMiddleware>();

=======
>>>>>>> ed2491a9edfc62b3d231383823927f345520eea2
app.UseAuthorization();

app.MapControllers();

app.Run();
