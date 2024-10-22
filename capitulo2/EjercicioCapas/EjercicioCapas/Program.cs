using EjercicioCapas.Data.Repositories;
using EjercicioCapas.Data;
using Microsoft.EntityFrameworkCore;
using EjercicioCapas.Bussiness.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injectar contexto de BD (Crear el objeto en tiempo de ejecución)
builder.Services.AddDbContext<AppDBContext>(
    context => {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConection"));
    }
);

/*Inyectar repositorios*/
builder.Services.AddScoped<AutorRepository>();
builder.Services.AddScoped<BookRepository>();

/*Inyectar servicios*/
builder.Services.AddScoped<IOperacionesServices, OperacionesServicesImpl>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
