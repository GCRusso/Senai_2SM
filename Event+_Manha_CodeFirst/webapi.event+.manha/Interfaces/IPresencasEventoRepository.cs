using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEventoDomain presencasEvento);
        void Delete(Guid id);
        List<PresencasEventoDomain> Listar();
        List<PresencasEventoDomain> ListarPresenca(Guid id);
        void Atualizar(Guid id, PresencasEventoDomain presencasEvento);
    }
}
