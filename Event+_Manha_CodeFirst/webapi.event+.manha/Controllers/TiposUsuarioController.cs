using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="tiposUsuario"></param>
        /// <returns> Cadastra um novo objeto na lista TiposUsuarioDomain </returns>
        [HttpPost]
        public IActionResult Post(TiposUsuarioDomain tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //********************* BUSCAR POR ID
        /// <summary>
        /// Endpoint que aciona o método BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna o objeto com o respectivo ID </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //********************* LISTAR
        /// <summary>
        /// EndPoint que aciona o método Listar
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista com os objetos cadastrados </returns>
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.Listar(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
