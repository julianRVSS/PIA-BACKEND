using Microsoft.AspNetCore.Mvc;
using WebApiTienda.Entidades;
using System.Security.Claims; 
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApiTienda.DTOs;

namespace WebApiTienda.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class AutencicacionController : ControllerBase
    {
        private readonly string secretkey; 

        public AutencicacionController(IConfiguration config){
            secretkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] AutenticacionDTO request){
            if(request.Correo == "admin@gmail.com" && request.Contraseña == "admin123"){
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Correo));

                var tokenDescriptor = new SecurityTokenDescriptor 
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)

                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new {token = tokencreado});
            }
            else{
                return StatusCode(StatusCodes.Status401Unauthorized, new {token = ""});
            }
        }
    }
}