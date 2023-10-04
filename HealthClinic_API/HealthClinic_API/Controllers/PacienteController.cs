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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;
        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        //**************************** ATUALIZAR PELO ID
        /// <summary>
        /// Endpoint que aciona o método ATUALIZAR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paciente"></param>
        /// <returns> Lista com objeto atualizado </returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return StatusCode(200);
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
        //[Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Post(Paciente paciente)
        {
            try
            {
                if (paciente != null)
                {
                    _pacienteRepository.Cadastrar(paciente);

                    return StatusCode(201);
                }
                return Ok("Paciente não foi inserida corretamente");
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
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);

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
        //[Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
