using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);

        List<Usuario> Listar(); 

        void Atualizar(Guid id, Usuario usuario); 

        void Deletar(Guid id);

        Usuario BuscarPorEmailESenha(string email, string senha);

    }
}
