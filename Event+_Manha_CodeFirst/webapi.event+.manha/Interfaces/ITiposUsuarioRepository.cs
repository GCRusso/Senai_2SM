using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuarioDomain tipoUsuario);

        void Deletar(Guid id);

        TiposUsuarioDomain BuscarPorId(Guid id);

        List<TiposUsuarioDomain> Listar();

        void Atualizar(Guid id, TiposUsuarioDomain tipoUsuario);

    }
}
