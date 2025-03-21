using ApiProcessos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiProcessos.Controllers
{

    [ApiController]
    [Route("api/conta")]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationController(SignInManager<IdentityUser> signInManager, 
                                        UserManager<IdentityUser> userManager,
                                        IOptions<JwtSettings> jwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(UsuariosRegistrados usuarioRegistrado)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = new IdentityUser
            {
                UserName = usuarioRegistrado.Email,
                Email = usuarioRegistrado.Email,
                EmailConfirmed = true


            };

            var result = await _userManager.CreateAsync(user, usuarioRegistrado.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(GerarJwt());
                
            
            
            }
            return Problem("Falha ao registrar novo usuário");

            
        
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)

        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);


            if (result.Succeeded)
            {
                
                return Ok( GerarJwt());



            }
            return Problem("email ou senha incorretos"); ;
        }


        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Segredo);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {

                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audiencia,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey (key), SecurityAlgorithms.HmacSha256Signature)



            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        
        
        }

    }
}
