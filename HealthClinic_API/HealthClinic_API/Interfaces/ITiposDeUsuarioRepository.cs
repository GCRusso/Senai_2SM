using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface ITiposDeUsuarioRepository
    {

        void Cadastrar(TiposDeUsuario tiposDeUsuario);

        void Deletar(Guid id);

        List<TiposDeUsuario> Listar();

    }
}
