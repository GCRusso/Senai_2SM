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
        /// <summary>
        /// Método que atualiza uma consulta cadastrada
        /// </summary>
        /// <param name="id">id consulta</param>
        /// <param name="consulta"> lista de consulta </param>
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
        /// <summary>
        /// Método que cadastra uma nova consulta
        /// </summary>
        /// <param name="consulta"> lista de consultas </param>
        public void Cadastrar(Consulta consulta)
        {
            consulta.IdConsulta = Guid.NewGuid();
            _healthContext.Consulta.Add(consulta);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta uma consulta cadastrada pelo seu id
        /// </summary>
        /// <param name="id">id consulta</param>
        public void Deletar(Guid id)
        {
            Consulta consulta = _healthContext.Consulta.Find(id)!;
            _healthContext.Consulta.Remove(consulta);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR POR MEDICO
        /// <summary>
        /// Método que lista as consultas por médico
        /// </summary>
        /// <param name="id"> id medico </param>
        /// <returns> lista de consultas por medico </returns>
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
        /// <summary>
        /// Método que lista as consultas por paciente
        /// </summary>
        /// <param name="id"> id paciente </param>
        /// <returns> lista de consultas por paciente </returns>
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
        /// <summary>
        /// Método que lista todas as consultas cadastradas
        /// </summary>
        /// <returns> lista com todas as consultas </returns>
        public List<Consulta> ListarTodos()
        {
            return _healthContext.Consulta.ToList();
        }
    }
}
