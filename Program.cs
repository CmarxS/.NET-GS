using Microsoft.EntityFrameworkCore;
using FloodianGlobal.Data;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.Infrastructure.Data.Repositories;
using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração da string de conexão com o banco de dados
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FloodianDbContext>(options =>
    options.UseOracle(connStr));

// Registro dos repositórios e serviços da aplicação
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorApplicationService, SensorApplicationService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();


// Adicionando os serviços para controllers, Swagger e endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurações de segurança e redirecionamento
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Iniciar a aplicação
app.Run();
