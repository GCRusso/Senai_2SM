using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;
using HealthClinic_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosConsultaController : ControllerBase
    {

        private IComentariosConsultaRepository _comentarioRepository;
        public ComentariosConsultaController()
        {
            _comentarioRepository = new ComentariosConsultaRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="comentariosConsulta"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]

        public IActionResult Post(ComentariosConsulta comentariosConsulta)
        {
            try
            {
                if (comentariosConsulta != null)
                {
                    _comentarioRepository.Cadastrar(comentariosConsulta);

                    return StatusCode(201);
                }
                return Ok("Consulta não foi inserida corretamente");
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
                _comentarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //********************* LISTAR
        /// <summary>
        /// Endpoint que aciona o método LISTAR
        /// </summary>
        /// <returns> lista de objetos </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //**************************** ATUALIZAR PELO ID
        /// <summary>
        /// Endpoint que aciona o método ATUALIZAR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comentariosConsulta"></param>
        /// <returns> Lista com objeto atualizado </returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, ComentariosConsulta comentariosConsulta)
        {
            try
            {
                _comentarioRepository.Atualizar(id, comentariosConsulta);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
