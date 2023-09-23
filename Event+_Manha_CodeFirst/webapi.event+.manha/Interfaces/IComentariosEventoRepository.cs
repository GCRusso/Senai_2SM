using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IComentariosEventoRepository
    {

        void Cadastrar(ComentariosEventoDomain comentariosEvento);

        void Deletar(Guid id);

        ComentariosEventoDomain BuscarPorId(Guid id);

        List<ComentariosEventoDomain> Listar();

        void Atualizar(Guid id, ComentariosEventoDomain comentariosEvento);
    }
}
