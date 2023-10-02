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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        //**************************** ATUALIZAR PELO ID
        /// <summary>
        /// Endpoint que aciona o método ATUALIZAR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="consulta"></param>
        /// <returns> Lista com objeto atualizado </returns>
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.Atualizar(id, consulta);
                return StatusCode(200);
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
        /// <param name="consulta"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]

        public IActionResult Post(Consulta consulta)
        {
            try
            {
                if (consulta != null)
                {
                    _consultaRepository.Cadastrar(consulta);

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
                _consultaRepository.Deletar(id);

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
                return Ok(_consultaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ********************** LISTAR POR MEDICO
        /// <summary>
        /// Endpoint que aciona o método ListarPorMedico
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista de objetos </returns>
        [HttpGet("Medico")]
        public IActionResult ListarPorMedico(Guid id)
        {
            try
            {
                List<Consulta> listaMedico = _consultaRepository.ListarPorMedico(id);
                return Ok(listaMedico);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ************************** LISTAR POR PACIENTE
        /// <summary>
        /// Endpoint que aciona o método Listar Por Paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista de objetos </returns>
        [HttpGet("Paciente")]
        public IActionResult ListarPorPaciente(Guid id)
        {
            try
            {
                List<Consulta> listaPaciente = _consultaRepository.ListarPorPaciente(id);
                return Ok(listaPaciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
