using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEventoDomain tipoEvento);

        void Deletar(Guid id);

        TiposEventoDomain BuscarPorId(Guid id);

        List<TiposEventoDomain> Listar();

        void Atualizar(Guid id, TiposEventoDomain tipoEvento);
    }
}
