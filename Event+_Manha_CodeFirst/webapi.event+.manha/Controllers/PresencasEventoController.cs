using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Repositories;

namespace webapi.event_.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        IPresencasEventoRepository _presencasRepository;
        public PresencasEventoController()
        {
            _presencasRepository = new PresencasEventoRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método Listar 
        /// </summary>
        /// <returns> Lista de objetos </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método Cadastrar
        /// </summary>
        /// <param name="presencasEvento"></param>
        /// <returns> Retorna a lista de objeto cadastrados </returns>
        [HttpPost]
        public IActionResult Post(PresencasEventoDomain presencasEvento)
        {
            try
            {
                if (presencasEvento != null)
                {
                    _presencasRepository.Cadastrar(presencasEvento);
                    return StatusCode(201);
                }
                return null;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Endpoint que aciona o método Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Deleta um objeto da lista </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencasRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                BadRequest(e.Message);
                throw;
            }
        }
        /// <summary>
        /// Endpoint que aciona o método Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presencasEvento"></param>
        /// <returns> Retorna a lista de objetos </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencasEventoDomain presencasEvento)
        {
            try
            {
                _presencasRepository.Atualizar(id, presencasEvento);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o Método ListarPresenca
        /// </summary>
        /// <param name="id"></param>
        /// <returns> lista de presenças do usuário buscado </returns>
        [HttpGet("{id}")]
        public IActionResult GetWithUser(Guid id)
        {
            try
            {
                return Ok(_presencasRepository.ListarPresenca(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
