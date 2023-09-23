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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="evento"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]

        public IActionResult Post(EventoDomain evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

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
                    return Ok(_eventoRepository.BuscarPorId(id));
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //*************************** DELETAR PELO ID
        /// <summary>
        /// EndPoint que aciona o método Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista com os objetos cadastrados </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //************************ ATUALIZAR PELO ID
        /// <summary>
        /// EndPoint que aciona o método Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns> Retorna a lista de objetos cadastrados </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, EventoDomain evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}

