using MicroservicioPerros.Bussiness.Services;
using MicroservicioPerros.Data;
using MicroservicioPerros.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Preparar inyección de DB*/
var ConnectionString = Environment.GetEnvironmentVariable("CONN_STR");

builder.Services.AddDbContext<AppDBContext>(
    context => {
        context.UseMySQL(ConnectionString ?? builder.Configuration.GetConnectionString("DefaultConnection")??"");
    }
);

/*Inyectar repositorios*/
builder.Services.AddScoped<DogRepository>();

/*Inyectar servicios*/
builder.Services.AddScoped<IDogService, DogServiceImpl>();

/*Allow origins*/
builder.Services.AddCors(
    options=> {
        options.AddPolicy(name:"AllowAny", 
            configurePolicy: policy => { 
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod(); 
            });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

/*Activate CORS*/
app.UseCors("AllowAny");

app.Run();