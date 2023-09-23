using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventoContext _eventoContext;
        public EventoRepository()
        {
            _eventoContext = new EventoContext();
        }

        // **************************** ATUALIZAR
        public void Atualizar(Guid id, EventoDomain evento)
        {
            EventoDomain eventoBuscado = _eventoContext.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.IdInstituicao = evento.IdInstituicao;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.NomeEvento = evento.NomeEvento;
            }
                _eventoContext.Update(eventoBuscado);
                _eventoContext.SaveChanges();
        }

        // **************************** BUSCAR POR ID
        public EventoDomain BuscarPorId(Guid id)
        {
            try
            {
                EventoDomain eventoBuscado = _eventoContext.Evento
                    .Select(u => new EventoDomain
                    {
                        IdEvento = u.IdEvento,

                    }).FirstOrDefault(u => u.IdEvento == id)!;

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

        // **************************** CADASTRAR
        public void Cadastrar(EventoDomain evento)
        {
            _eventoContext.Evento.Add(evento);

            _eventoContext.SaveChanges();
        }

        // **************************** DELETAR
        public void Deletar(Guid id)
        {
            EventoDomain evento = _eventoContext.Evento.Find(id)!;
            _eventoContext.Evento.Remove(evento);
            _eventoContext.SaveChanges();
        }

        // **************************** LISTAR
        public List<EventoDomain> Listar()
        {
            return _eventoContext.Evento.ToList();
        }
    }
}
