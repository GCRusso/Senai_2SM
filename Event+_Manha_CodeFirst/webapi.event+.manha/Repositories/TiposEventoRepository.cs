using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Repositories
{
    public class TiposEventoRepository
    {
        private readonly EventoContext _eventoContext;
        public TiposEventoRepository()
        {
            _eventoContext = new EventoContext();
        }

        //********************* CADASTRAR
        public void Cadastrar(TiposEventoDomain tipoEvento)
        {
            _eventoContext.TiposEvento.Add(tipoEvento);

            _eventoContext.SaveChanges();
        }

        //********************* DELETAR
        public void Deletar(Guid id)
        {
            TiposEventoDomain tiposEvento = _eventoContext.TiposEvento.Find(id)!;
            _eventoContext.TiposEvento.Remove(tiposEvento);
            _eventoContext.SaveChanges();
        }

        //********************* BUSCAR POR ID
        public TiposEventoDomain BuscarPorId(Guid id)
        {
            try
            {
                TiposEventoDomain eventoBuscado = _eventoContext.TiposEvento
                    .Select(u => new TiposEventoDomain
                    {
                        IdTipoEvento = u.IdTipoEvento,
                        Titulo = u.Titulo,

                    }).FirstOrDefault(u => u.IdTipoEvento == id)!;

                if (eventoBuscado != null)
                {
                    return eventoBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // ****************** LISTAR TODOS
        public List<TiposEventoDomain> Listar()
        {
            return _eventoContext.TiposEvento.ToList();
        }

        //********************* ATUALIZAR
        public void Atualizar(Guid id, TiposEventoDomain tipoEvento)
        {
            TiposEventoDomain tipoEventoBuscado = _eventoContext.TiposEvento.Find(id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;
            }
            _eventoContext.Update(tipoEventoBuscado);
            _eventoContext.SaveChanges();
        }
    }
}
