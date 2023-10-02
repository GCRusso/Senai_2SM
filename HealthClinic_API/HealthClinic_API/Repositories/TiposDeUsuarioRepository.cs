using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class TiposDeUsuarioRepository : ITiposDeUsuarioRepository
    {

        private readonly HealthContext _healthContext;
        public TiposDeUsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** CADASTRAR
        /// <summary>
        /// Método que cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="tiposDeUsuario"> lista de tipos de usuario </param>
        public void Cadastrar(TiposDeUsuario tiposDeUsuario)
        {
            tiposDeUsuario.IdTipoDeUsuario = Guid.NewGuid();
            _healthContext.TiposDeUsuario.Add(tiposDeUsuario);
            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta um tipo de usuário pelo seu id
        /// </summary>
        /// <param name="id"> id de tipo de usuário </param>
        public void Deletar(Guid id)
        {
            TiposDeUsuario tiposDeUsuario = _healthContext.TiposDeUsuario.Find(id)!;
            _healthContext.TiposDeUsuario.Remove(tiposDeUsuario);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método que lista todos os tipos de usuários cadastrados
        /// </summary>
        /// <returns> lista de objetos </returns>
        public List<TiposDeUsuario> Listar()
        {
            return _healthContext.TiposDeUsuario.ToList();
        }
    }
}
