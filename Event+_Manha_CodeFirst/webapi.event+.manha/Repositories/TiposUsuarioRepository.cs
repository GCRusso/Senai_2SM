using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventoContext _eventoContext;
        public TiposUsuarioRepository()
        {
            _eventoContext= new EventoContext();
        }



        //********************* CADASTRAR
        public void Cadastrar(TiposUsuarioDomain tipoUsuario)
        {
            _eventoContext.TiposUsuario.Add(tipoUsuario);

            _eventoContext.SaveChanges();
        }

        //********************* DELETAR
        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        //********************* BUSCAR POR ID
        public TiposUsuarioDomain BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuarioDomain usuarioBuscado = _eventoContext.TiposUsuario
                    .Select(u => new TiposUsuarioDomain
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.Titulo,

                    }).FirstOrDefault(u => u.IdTipoUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // ****************** LISTAR TODOS
        public List<TiposUsuarioDomain> Listar(Guid id)
        {
            return _eventoContext.TiposUsuario.ToList();
        }

        //********************* ATUALIZAR
        public void Atualizar(Guid id, TiposUsuarioDomain tipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
