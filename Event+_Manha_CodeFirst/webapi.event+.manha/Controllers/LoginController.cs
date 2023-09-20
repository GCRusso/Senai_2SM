using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;
using webapi.event_.manha.ViewModels;

namespace webapi.event_.manha.Controllers
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

        [HttpPost]
        public IActionResult Post(LoginViewModel usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou Senha inválidos!");
                }
                
                //CRIANDO O JWT
                //Caso encontre o usuário, prossegue para a criação do token

                //1º - Definir as informações(Claims) que serão fornecidos no token (PAYLOAD)

                var claims = new[]
                {
                    //Usado JTI para ID
                    new Claim(JwtRegisteredClaimNames.Name,usuarioBuscado.Nome!),
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim(ClaimTypes.Role,usuarioBuscado.TiposUsuario!.Titulo!),
                    

                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso ao token, tem que ser uma chave de grande porte como esta que estamos utilizando, bem detalhada.
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("event-webapi-chaves-autenticacao-webapi-dev"));

                //3º - Definir as credenciais do token (HEADER), pede a chave que declaramos a cima e depois o tipo de criptografia
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar Token
                var token = new JwtSecurityToken
                (
                    //Emissor do Token
                    issuer: "webapi.event+.manha",

                    //Destinatario do Token
                    audience: "webapi.event+.manha",

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
