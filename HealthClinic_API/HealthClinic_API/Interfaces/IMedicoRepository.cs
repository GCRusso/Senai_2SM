using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IMedicoRepository
    {

        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        Medico BuscarPorId(Guid id);

        List<Medico> Listar();

        void Atualizar(Guid id, Medico medico);

    }
}
