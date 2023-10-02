using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;
        public EspecialidadeRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** CADASTRAR
        /// <summary>
        /// Método que cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade"> Id especialidade </param>
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                especialidade.IdEspecialidade = Guid.NewGuid();
                _healthContext.Especialidade.Add(especialidade);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta uma especialidade pelo seu id
        /// </summary>
        /// <param name="id"> id especialidade </param>
        public void Deletar(Guid id)
        {
            Especialidade especialidade = _healthContext.Especialidade.Find(id)!;
            _healthContext.Especialidade.Remove(especialidade);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método que lista todas as especialidades cadastradas
        /// </summary>
        /// <returns> lista de especialidades </returns>
        public List<Especialidade> Listar()
        {
            return _healthContext.Especialidade.ToList();
        }
    }
}
