using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IEventoRepository
    {

        void Cadastrar(EventoDomain evento);

        void Deletar(Guid id);

        EventoDomain BuscarPorId(Guid id);

        List<EventoDomain> Listar();

        void Atualizar(Guid id, EventoDomain evento);
    }
}
