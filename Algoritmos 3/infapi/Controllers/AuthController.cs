using Microsoft.AspNetCore.Mvc;
using ConAPI.Domain;
using ConAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace ConAPI.Controllers;



[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IUserRepository _repository;
    private IConfiguration _config;
    
    public AuthController(IUserRepository repository, IConfiguration config)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("create")]
    [Authorize]
    public async Task<IActionResult> CreateUser([FromBody]User request)
    {
        int result = await _repository.CreateUser(request);
        string message = "Usuario creado correctamente";
        return Ok(new {id = result, message});
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EPkEoWpSwio1wENYdQfIyFqc5wwHz6Tk"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new[]
        {
            new Claim("Id_user", "3"),
            new Claim("email", "test@test.co"),
            new Claim("saldo", "$400")
        };

        var token = new JwtSecurityToken(
            issuer: "localhost",             
            audience: "localhost",           
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );

        var rsp = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(rsp);
    }


}