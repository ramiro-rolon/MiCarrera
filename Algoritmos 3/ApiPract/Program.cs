/*
    1. Parametrizar las configuraciones y keys usando la interfaz intf IConfiguration

    2. Crear un endpoint para registrar nuevos usuarios

    3. Crear un endpoint de login

    4. crear un endpoint que traiga un listado de usuarios que requiera JWT
*/

using ApiPract.Repository;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            ValidIssuer = "localhost",                      
            ValidAudience = "localhost",                   
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:Key").Value) 
            )
        };
    });

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepositorio, MSSQLUsuarioRepositorio>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();