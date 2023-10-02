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
        /// <summary>
        /// Método que atualiza os dados de um medico
        /// </summary>
        /// <param name="id"> id de medico</param>
        /// <param name="medico"> lista de medicos </param>
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
            /// <summary>
            /// Método para buscar um medico pelo seu id
            /// </summary>
            /// <param name="id"> id de medico </param>
            /// <returns> todos os dados de um medico cadastrado </returns>
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
        /// <summary>
        /// Método que cadastra um novo médico na lista
        /// </summary>
        /// <param name="medico"> id de medico </param>
        public void Cadastrar(Medico medico)
        {
            medico.IdMedico = Guid.NewGuid();
            _healthContext.Medico.Add(medico);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta o medico buscando pelo seu id
        /// </summary>
        /// <param name="id"> id medico </param>
        public void Deletar(Guid id)
        {
            Medico medico = _healthContext.Medico.Find(id)!;
            _healthContext.Medico.Remove(medico);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método que lista todos os médicos cadastrados
        /// </summary>
        /// <returns> Lista de médicos </returns>
        public List<Medico> Listar()
        {
            return _healthContext.Medico.ToList();
        }
    }
}
