using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;
using HealthClinic_API.Repositories;
using HealthClinic_API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthClinic_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        /// <summary>
        /// Endpoint que aciona o método Login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> Usuário logado </returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou Senha inválidos!");
                }

                var claims = new[]
                {
               
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(ClaimTypes.Role,usuarioBuscado.TiposDeUsuario!.Titulo!),
                    
                };

                //2º - Definir a chave de acesso ao token, tem que ser uma chave de grande porte como esta que estamos utilizando, bem detalhada.
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-webapi-chaves-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token (HEADER), pede a chave que declaramos a cima e depois o tipo de criptografia
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar Token
                var token = new JwtSecurityToken
                (
                    //Emissor do Token
                    issuer: "HealthClinic_API",

                    //Destinatario do Token
                    audience: "HealthClinic_API",

                    //Dados definidos nas claims(Informações)
                    claims: claims,

                    //Tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //5º - Retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
