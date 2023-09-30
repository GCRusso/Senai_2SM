using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IComentariosConsultaRepository
    {

        void Cadastrar(ComentariosConsulta comentariosConsulta);

        void Deletar(Guid id);

        List<ComentariosConsulta> ListarTodos();

        void Atualizar(Guid id, ComentariosConsulta comentariosConsulta);

    }
}
