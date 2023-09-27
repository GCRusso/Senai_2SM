using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IPacienteRepository
    {

        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        Paciente BuscarPorId(Guid id);

        List<Paciente> Listar();

        void Atualizar(Guid id, Paciente paciente);

    }
}
