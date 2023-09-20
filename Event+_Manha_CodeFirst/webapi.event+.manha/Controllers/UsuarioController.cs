using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //******************** CADASTRAR
        /// <summary>
        /// EndPoint que aciona o método Cadastrar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> Adiciona um novo objeto na lista UsuarioDomain </returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //************************* BUSCAR POR ID
        /// <summary>
        /// EndPoint que aciona o método BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna o objeto cadastrado com o respectivo ID </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //************************* BUSCAR POR EMAIL E SENHA
        [HttpGet]

        public IActionResult Get(string email, string senha) 
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email,senha);

                if (usuarioBuscado == null)
                {
                    //Caso nao seja encontrado retorna esta mensagem personalizada e o erro 404
                    return NotFound("Nenhum usuário foi encontrado!");
                }

                return Ok(usuarioBuscado);
                
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
