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




        public void Cadastrar(TiposUsuarioDomain tipoUsuario)
        {
            _eventoContext.TiposUsuario.Add(tipoUsuario);

            _eventoContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public TiposUsuarioDomain BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }


        public List<TiposUsuarioDomain> Listar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Guid id, TiposUsuarioDomain tipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
