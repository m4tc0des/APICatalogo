using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // Criação do builder do aplicativo

// Add services to the container.

builder.Services.AddControllers(); // Adiciona suporte a controladores
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para exploração de endpoints
builder.Services.AddSwaggerGen(); // Adiciona suporte para geração de documentação Swagger

string MySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection"); // Obtém a string de conexão do MySQL do arquivo de configuração
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection)) // Configura o DbContext para usar MySQL com detecção automática da versão do servidor
);

var app = builder.Build(); // Criação do aplicativo


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS

app.UseAuthorization(); // Adiciona middleware de autorização

app.MapControllers(); // Mapeia os controladores para os endpoints

app.Run(); // Executa o aplicativo
