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
        Description = "Documenta��o da API REST para o sistema Floodian" +
                                "� Sistema Inteligente de Monitoramento e Alerta de Enchentes\n" +
                                "\n" +
                                "Sistema IoT para monitoramento em tempo real do n�vel de �gua e precipita��o em �reas urbanas" +
                                " e rurais, visando preven��o de desastres relacionados a enchentes. Utiliza sensores instalados " +
                                "em pontos estrat�gicos que enviam dados via MQTT para um gateway que processa as informa��es e " +
                                "gera alertas conforme regras configuradas. A API RESTful disponibiliza endpoints para consulta " +
                                "de sensores, cadastro de usuarios e sensores. A solu��o conta ainda com " +
                                "um aplicativo para notifica��o imediata, al�m de alarmes locais para alertar " +
                                "comunidades. O sistema contribui para a seguran�a p�blica, engajamento comunit�rio e apoio a " +
                                "pol�ticas p�blicas, sendo escal�vel para amplia��o a novas regi�es."
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
