using Microsoft.EntityFrameworkCore;
using FloodianGlobal.Data;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.Infrastructure.Data.Repositories;
using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da string de conex�o com o banco de dados
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FloodianDbContext>(options =>
    options.UseOracle(connStr));

// Registro dos reposit�rios e servi�os da aplica��o
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorApplicationService, SensorApplicationService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();


// Adicionando os servi�os para controllers, Swagger e endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura��o do Swagger para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura��es de seguran�a e redirecionamento
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Iniciar a aplica��o
app.Run();
