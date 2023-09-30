using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;
        public ConsultaRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** ATUALIZAR
        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta consultaBuscada = _healthContext.Consulta.Find(id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.DataConsulta = consulta.DataConsulta;
                consultaBuscada.HorarioConsulta = consulta.HorarioConsulta;
                consultaBuscada.Descricao = consulta.Descricao;
                consultaBuscada.IdMedico = consulta.IdMedico;
                consultaBuscada.IdPaciente = consulta.IdPaciente;
            }
            _healthContext.Update(consultaBuscada);
            _healthContext.SaveChanges();
        }

        //**************************** CADASTRAR
        public void Cadastrar(Consulta consulta)
        {
            consulta.IdConsulta = Guid.NewGuid();
            _healthContext.Consulta.Add(consulta);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            Consulta consulta = _healthContext.Consulta.Find(id)!;
            _healthContext.Consulta.Remove(consulta);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR POR MEDICO
        public List<Consulta> ListarPorMedico(Guid id)
        {
            List<Consulta> lista = new List<Consulta>();

            foreach (var consulta in _healthContext.Consulta)
            {
                if (consulta.IdMedico == id)
                {
                    lista.Add(consulta);
                }
            }

            return lista;
        }

        //**************************** LISTAR POR PACIENTE
        public List<Consulta> ListarPorPaciente(Guid id)
        {
            List<Consulta> lista = new List<Consulta>();

            foreach (var consulta in _healthContext.Consulta)
            {
                if (consulta.IdPaciente == id)
                {
                    lista.Add(consulta);
                }
            }

            return lista;
        }

        //**************************** LISTAR TODOS
        public List<Consulta> ListarTodos()
        {
            return _healthContext.Consulta.ToList();
        }
    }
}
