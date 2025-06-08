using Microsoft.EntityFrameworkCore;
using FloodianGlobal.Data;
using FloodianGlobal.Domain.Interfaces;
using FloodianGlobal.Infrastructure.Data.Repositories;
using FloodianGlobal.Application.Interfaces;
using FloodianGlobal.Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FloodianDbContext>(options =>
    options.UseOracle(connStr));
builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorApplicationService, SensorApplicationService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Floodian API",
        Version = "v1",
        Description = "Documentação da API REST para o sistema Floodian" +
                                "— Sistema Inteligente de Monitoramento e Alerta de Enchentes\n" +
                                "\n" +
                                "Sistema IoT para monitoramento em tempo real do nível de água e precipitação em áreas urbanas" +
                                " e rurais, visando prevenção de desastres relacionados a enchentes. Utiliza sensores instalados " +
                                "em pontos estratégicos que enviam dados via MQTT para um gateway que processa as informações e " +
                                "gera alertas conforme regras configuradas. A API RESTful disponibiliza endpoints para consulta " +
                                "de sensores, cadastro de usuarios e sensores. A solução conta ainda com " +
                                "um aplicativo para notificação imediata, além de alarmes locais para alertar " +
                                "comunidades. O sistema contribui para a segurança pública, engajamento comunitário e apoio a " +
                                "políticas públicas, sendo escalável para ampliação a novas regiões."
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Floodian API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
