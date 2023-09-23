using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventoContext _eventoContext;
        public InstituicaoRepository()
        {
            _eventoContext = new EventoContext();
        }
        public void Cadastrar(InstituicaoDomain instituicao)
        {
            _eventoContext.Instituicao.Add(instituicao);
            _eventoContext.SaveChanges();
        }
    }
}
