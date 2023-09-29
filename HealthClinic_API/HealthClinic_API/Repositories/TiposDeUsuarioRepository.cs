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
        public void Cadastrar(TiposDeUsuario tiposDeUsuario)
        {
            tiposDeUsuario.IdTipoDeUsuario = Guid.NewGuid();
            _healthContext.TiposDeUsuario.Add(tiposDeUsuario);
            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            TiposDeUsuario tiposDeUsuario = _healthContext.TiposDeUsuario.Find(id)!;
            _healthContext.TiposDeUsuario.Remove(tiposDeUsuario);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<TiposDeUsuario> Listar()
        {
            return _healthContext.TiposDeUsuario.ToList();
        }
    }
}
