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
    public class InstituicaoController : ControllerBase
    {

        IInstituicaoRepository _instituicaoRepository;
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]

        public IActionResult Post(InstituicaoDomain instituicao)
        {
            try
            {
                if (instituicao != null)
                {
                    _instituicaoRepository.Cadastrar(instituicao);
                    return Ok("Usuário Cadastrado");

                }

                return Ok("Usuário é obrigatório!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
