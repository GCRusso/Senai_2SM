using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;
using HealthClinic_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthClinic_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="especialidade"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                if (especialidade != null)
                {
                    _especialidadeRepository.Cadastrar(especialidade);

                    return StatusCode(201);
                }
                return Ok("Clinica não foi inserida corretamente");
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
                _especialidadeRepository.Deletar(id);

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
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
