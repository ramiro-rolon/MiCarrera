using ConAPI.Repositories;
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
                Encoding.UTF8.GetBytes("EPkEoWpSwio1wENYdQfIyFqc5wwHz6Tk") 
            )
        };
    });

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISimpleObjectRepository, MSSQLSimpleObjectRepository>();
builder.Services.AddScoped<IUserRepository, MSSQLServerUserRepository>();

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
