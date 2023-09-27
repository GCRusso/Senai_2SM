using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IConsultaRepository
    {

        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Clinica> ListarTodos();

        void Atualizar(Guid id, Consulta consulta);

        List<Clinica> ListarPorPaciente(Guid id);

        List<Clinica> ListarPorMedico(Guid id);

    }
}
