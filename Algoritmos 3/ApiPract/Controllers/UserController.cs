using Microsoft.AspNetCore.Mvc;
using ApiPract.Domain;
using ApiPract.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
namespace ApiPract.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase 
{
    private IUsuarioRepositorio _repository;    
    private IConfiguration _config;
    
    public UserController(IUsuarioRepositorio repository, IConfiguration config)
    {
        _repository = repository;
        _config = config;
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetUsuarios()
    {
        var users = await _repository.GetUsuarios();
        string message = "Usuarios obtenidos correctamente";
        return Ok(new { users, message });
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> InsertarUsuarios([FromBody]Usuario request)
    {
        int result = await _repository.InsertUsuarios(request);
        string message = "Usuario creado correctamente";
        return Ok(new {id = result, message});
    }   

    [HttpDelete]
    [Route("delete")]
    [Authorize]
    public async Task<IActionResult> DeleteUsuarios([FromBody]int request)
    {
        var users = await _repository.DeleteUsuarios(request);
        string message = "Usuarios eliminados correctamente";
        return Ok(new { users, message });
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequest request)
    {
        var usuarios = await _repository.GetUsuarios();
        var user = usuarios.FirstOrDefault(u => u.mail == request.email && u.pass == request.pass);

        if (user == null)
        {
            return Unauthorized(new { message = "Credenciales inválidas" });
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.nombre),
            new Claim(ClaimTypes.Email, user.mail),
            new Claim("id", user.id.ToString())
        };

        var secretKey = _config.GetSection("JwtSettings:Key").Value;
        var issuer = _config.GetSection("JwtSettings:Issuer").Value;
        var audience = _config.GetSection("JwtSettings:Audience").Value;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return Ok(new { message = "Login successful" });
    }

}