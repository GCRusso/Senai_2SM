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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //******************** ATUALIZAR
        /// <summary>
        /// EndPoint que aciona o método Atualizar
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns> Retorna a lista de objetos atualizada </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //******************** CADASTRAR
        /// <summary>
        /// EndPoint que aciona o método Cadastrar
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> Adiciona um novo objeto na lista UsuarioDomain </returns>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //********************** LISTAR 
        /// <summary>
        /// EndPoint que aciona o método Listar
        /// </summary>
        /// <returns> Retorna a lista completa de objetos cadastrados </returns>
        [HttpGet("todos")]

        public IActionResult GetAction()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //********************** DELETAR PELO ID
        /// <summary>
        /// Endpoint que aciona o método DELETAR
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Objeto deletado </returns>S
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //************************* BUSCAR POR EMAIL E SENHA
        /// <summary>
        /// EndPoint que aciona o método BuscarPorEmailESenha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns> Retorna o objeto cadastrado(usuário) </returns>
        [HttpGet]

        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado == null)
                {
                    //Caso nao seja encontrado retorna esta mensagem personalizada e o erro 404
                    return NotFound("Nenhum usuário foi encontrado!");
                }

                return Ok(usuarioBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
