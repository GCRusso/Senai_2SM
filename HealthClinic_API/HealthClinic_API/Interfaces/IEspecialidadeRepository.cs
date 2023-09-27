using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IEspecialidadeRepository
    {

        void Cadastrar(Especialidade especialidade);

        void Deletar(Guid id);

        List<Especialidade> Listar();
    }
}
