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
        public Clinica BuscarPorId(Guid id)
        {
            try
            {
                Clinica clinicaBuscada = _healthContext.Clinica
                    .Select(u => new Clinica
                    {
                        IdClinica = u.IdClinica,
                        NomeFantasia = u.NomeFantasia,
                        Endereco= u.Endereco,
                        RazaoSocial= u.RazaoSocial,
                        HorarioAbertura= u.HorarioAbertura,
                        HorarioFechamento= u.HorarioFechamento,
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
        public void Cadastrar(Clinica clinica)
        {
             clinica.IdClinica = Guid.NewGuid();
            _healthContext.Clinica.Add(clinica);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            Clinica clinica= _healthContext.Clinica.Find(id)!;
            _healthContext.Clinica.Remove(clinica);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR TODOS
        public List<Clinica> Listar()
        {
            return _healthContext.Clinica.ToList();
        }

    }
}
