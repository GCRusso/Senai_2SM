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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }
    }


    //********************* CADASTRAR
    /// <summary>
    /// EndPoint que aciona o metodo Cadastrar
    /// </summary>
    /// <param name="tipoEvento"></param>
    /// <returns> Cadastra um novo objeto na lista </returns>
    [HttpPost]

    public IActionResult Post(TiposEventoDomain tipoEvento)
    {
        try
        {
            _tiposEventoRepository.Cadastrar(tipoEvento);

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
            return Ok(_tiposEventoRepository.BuscarPorId(id));
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
    /// <returns> Retorna a lista de objetos </returns>
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_tiposEventoRepository.Listar());
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
            _tiposEventoRepository.Deletar(id);

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
  /// <param name="tiposEvento"></param>
  /// <returns> Retorna a lista de objeto </returns>
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, TiposEventoDomain tiposEvento)
    {
        try
        {
            _tiposEventoRepository.Atualizar(id, tiposEvento);
            return StatusCode(200);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
