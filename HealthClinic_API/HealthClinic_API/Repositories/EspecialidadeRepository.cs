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
        public void Deletar(Guid id)
        {
            Especialidade especialidade = _healthContext.Especialidade.Find(id)!;
            _healthContext.Especialidade.Remove(especialidade);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<Especialidade> Listar()
        {
            return _healthContext.Especialidade.ToList();
        }
    }
}
