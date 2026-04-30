/*
    1. Parametrizar las configurtacuiones y keys usando la interfaz intf IConfiguration

    2. Crear un endpoint para registrar nuevos usuarios

    3. Crear un endpoint de login

    4. crear un endpoint que traiga un listado de usuarios que requiera JWT
*/

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
