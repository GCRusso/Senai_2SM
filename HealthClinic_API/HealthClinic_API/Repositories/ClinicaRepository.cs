using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;
        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** ATUALIZAR
        /// <summary>
        /// Método que atualiza uma clinica cadastrada
        /// </summary>
        /// <param name="id"> id clinica </param>
        /// <param name="clinica"> lista de clinica </param>
        public void Atualizar(Guid id, Clinica clinica)
        {
            Clinica clinicaBuscada = _healthContext.Clinica.Find(id)!;

            if (clinicaBuscada != null)
            {
                clinicaBuscada.NomeFantasia = clinica.NomeFantasia;
                clinicaBuscada.Endereco = clinica.Endereco;
                clinicaBuscada.RazaoSocial = clinica.RazaoSocial;
                clinicaBuscada.HorarioAbertura = clinica.HorarioAbertura;
                clinicaBuscada.HorarioFechamento = clinica.HorarioFechamento;
                clinicaBuscada.CNPJ = clinica.CNPJ;
            }
            _healthContext.Update(clinicaBuscada);
            _healthContext.SaveChanges();
        }

        //**************************** BUSCAR POR ID
        /// <summary>
        /// Método que a clinica pelo seu id
        /// </summary>
        /// <param name="id"> id clinica </param>
        /// <returns> Todos os dados da clinica cadastrada </returns>
        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _healthContext.Clinica
                    .Select(u => new Clinica
                    {
                        IdClinica = u.IdClinica,
                        NomeFantasia = u.NomeFantasia,
                        Endereco = u.Endereco,
                        RazaoSocial = u.RazaoSocial,
                        HorarioAbertura = u.HorarioAbertura,
                        HorarioFechamento = u.HorarioFechamento,
                        CNPJ = u.CNPJ,
                    }).FirstOrDefault(u => u.IdClinica == id)!;

                if (clinicaBuscada != null)
                {
                    return clinicaBuscada;
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
        /// Método que cadastra uma nova clinica
        /// </summary>
        /// <param name="clinica"> lista de clinica </param>
        public void Cadastrar(Clinica clinica)
        {
             clinica.IdClinica = Guid.NewGuid();
            _healthContext.Clinica.Add(clinica);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta uma clinica buscando pelo seu id
        /// </summary>
        /// <param name="id"> id clinica </param>
        public void Deletar(Guid id)
        {
            Clinica clinica= _healthContext.Clinica.Find(id)!;
            _healthContext.Clinica.Remove(clinica);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR TODOS
        /// <summary>
        /// Método que lista todos as clinicas cadastradas
        /// </summary>
        /// <returns> Lista de clinicas </returns>
        public List<Clinica> Listar()
        {
            return _healthContext.Clinica.ToList();
        }

    }
}
