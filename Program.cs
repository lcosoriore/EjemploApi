using EjemploApi;
using EjemploApi.Interfaces;
using EjemploApi.Middleware;
using EjemploApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>(@"Data Source=YINNY_PC\SQLEXPRESS;Initial Catalog=TareasDb;Integrated Security=SSPI; TrustServerCertificate=True;encrypt=false;");
builder.Services.AddScoped<IHelloworldServices, HelloworldServices>();
//Esta es una forma de inyectar dependencias usando directamente la clase pero no es lo mas recomendado viola los principios SOLID
//builder.Services.AddScoped<IHelloworldServices>(p=> new HelloworldServices());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
