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
    public class TiposDeUsuarioController : ControllerBase
    {

        private ITiposDeUsuarioRepository _tiposDeUsuarioRepository;
        public TiposDeUsuarioController()
        {
            _tiposDeUsuarioRepository = new TiposDeUsuarioRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="tiposDeUsuario"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Post(TiposDeUsuario tiposDeUsuario)
        {
            try
            {
                if (tiposDeUsuario != null)
                {
                    _tiposDeUsuarioRepository.Cadastrar(tiposDeUsuario);

                    return StatusCode(201);
                }
                return Ok("Tipo de usuário não foi inserido corretamente");
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
                _tiposDeUsuarioRepository.Deletar(id);

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
                return Ok(_tiposDeUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
