using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;
        public MedicoRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** ATUALIZAR
        public void Atualizar(Guid id, Medico medico)
        {
            Medico medicoBuscado = _healthContext.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;
                medicoBuscado.Especialidade= medico.Especialidade;
                medicoBuscado.Clinica = medico.Clinica;
                medicoBuscado.Usuario = medico.Usuario;
            }
            _healthContext.Update(medicoBuscado);
            _healthContext.SaveChanges();
        }


            //**************************** BUSCAR POR ID
            public Medico BuscarPorId(Guid id)
            {
                try
                {
                    Medico medicoBuscado = _healthContext.Medico
                        .Select(u => new Medico
                        {
                            IdMedico = u.IdMedico,
                            Especialidade= u.Especialidade,
                            Clinica= u.Clinica,
                            Usuario= u.Usuario,

                        }).FirstOrDefault(u => u.IdMedico == id)!;

                    if (medicoBuscado != null)
                    {
                        return medicoBuscado;
                    }
                    return null!;
                }
                catch (Exception)
                {

                    throw;
                }
            }

        //**************************** CADASTRAR
        public void Cadastrar(Medico medico)
        {
            medico.IdMedico = Guid.NewGuid();
            _healthContext.Medico.Add(medico);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            Medico medico = _healthContext.Medico.Find(id)!;
            _healthContext.Medico.Remove(medico);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<Medico> Listar()
        {
            return _healthContext.Medico.ToList();
        }
    }
}
