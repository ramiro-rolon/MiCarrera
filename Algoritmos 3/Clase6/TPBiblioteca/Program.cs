using Microsoft.Data.SqlClient; // O el driver que estés usando
using System.Data;

// ... (después de crear el builder)

// 1. Obtener la cadena de conexión del appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar la conexión en el contenedor de dependencias
// Usamos AddScoped para que se cree una conexión por cada petición HTTP y se cierre al terminar
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// ... (resto de tus registros de servicios)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

using BilleteraVirtualApi.Features.Cuentas; // Asegurate de usar el namespace correcto de tus features

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRO DE SERVICIOS (Inyección de Dependencias)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aquí irán tus AddScoped para los Services y Repositories de cada Feature más adelante.

var app = builder.Build();

// 2. CONFIGURACIÓN DEL PIPELINE HTTP (Middlewares)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. REGISTRO DE ENDPOINTS MODULARES
// Aquí llamaremos a nuestros métodos de extensión estáticos de cada Feature
// Ejemplo: app.MapCuentaEndpoints();

app.Run();
