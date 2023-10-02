using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;
        public PacienteRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** ATUALIZAR
        /// <summary>
        /// Método que atualiza os dados de um paciente
        /// </summary>
        /// <param name="id"> id de paciente </param>
        /// <param name="paciente"> lista de pacientes </param>
        public void Atualizar(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = _healthContext.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.Telefone = paciente.Telefone;
                pacienteBuscado.CPF = paciente.CPF;
                pacienteBuscado.Genero = paciente.Genero;
                pacienteBuscado.DataNascimento = paciente.DataNascimento;
                pacienteBuscado.IdUsuario = paciente.IdUsuario;
            }
            _healthContext.Update(pacienteBuscado);
            _healthContext.SaveChanges();
        }

        //**************************** BUSCAR POR ID
        /// <summary>
        /// Método que busca o paciente pelo seu id
        /// </summary>
        /// <param name="id"> id de paciente </param>
        /// <returns> todos os dados do paciente buscado </returns>
        public Paciente BuscarPorId(Guid id)
        {
            try
            {
                Paciente pacienteBuscado = _healthContext.Paciente
                    .Select(u => new Paciente
                    {
                        IdPaciente = u.IdPaciente,
                        CPF = u.CPF,
                        Genero = u.Genero,
                        DataNascimento = u.DataNascimento,
                        IdUsuario = u.IdUsuario,

                    }).FirstOrDefault(u => u.IdPaciente == id)!;

                if (pacienteBuscado != null)
                {
                    return pacienteBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** CADASTRAR
        /// <summary>
        /// Método para cadastrar um novo paciente
        /// </summary>
        /// <param name="paciente"> lista de pacientes </param>
        public void Cadastrar(Paciente paciente)
        {
            paciente.IdPaciente = Guid.NewGuid();
            _healthContext.Paciente.Add(paciente);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método para deletar o paciente buscando pelo seu id
        /// </summary>
        /// <param name="id"> id do paciente </param>
        public void Deletar(Guid id)
        {
            Paciente paciente = _healthContext.Paciente.Find(id)!;
            _healthContext.Paciente.Remove(paciente);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método para listar todos os pacientes cadastrados
        /// </summary>
        /// <returns> lista de pacientes </returns>
        public List<Paciente> Listar()
        {
            return _healthContext.Paciente.ToList();
        }
    }
}
