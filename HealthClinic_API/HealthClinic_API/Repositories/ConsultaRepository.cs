using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Atualizar(Guid id, Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consulta consulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarPorMedico(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarPorPaciente(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
