using gerenciamento_Ti.DTO;
using gerenciamento_Ti.Services.Implementation;
using gerenciamento_Ti.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace gerenciamento_Ti.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioService _usuarioService;

        public LoginController(
            IConfiguration config,
            IUsuarioService usuarioService)
        {
            _config = config;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UsuarioDTO usuarioDTO)
        {
            var usuario = await _usuarioService.GetByEmail(usuarioDTO.Email);

            if (usuario == null)
                return Unauthorized("Usuario não encontrado");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(
                usuarioDTO.Senha,
                usuario.SenhaHash
                );

            if (!senhaValida)
                return Unauthorized("Usuário inválido");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                //new Claim(ClaimTypes.Role, usuario.Role) //Permissão ou referencia de nível de acesso
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(25),
                signingCredentials: creds
            );

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
