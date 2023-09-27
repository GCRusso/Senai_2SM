using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IClinicaRepository
    {

        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        Clinica BuscarPorId(Guid id);

        List<Clinica> Listar();

        void Atualizar(Guid id, Clinica clinica);
    }
}
