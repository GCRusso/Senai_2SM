using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class ComentariosConsultaRepository : IComentariosConsultaRepository
    {
        private readonly HealthContext _healthContext;
        public ComentariosConsultaRepository()
        {
            _healthContext = new HealthContext();
        }
        //**************************** ATUALIZAR
        public void Atualizar(Guid id, ComentariosConsulta comentariosConsulta)
        {
            ComentariosConsulta comentarioBuscado = _healthContext.ComentariosConsultas.Find(id)!;

            if (comentarioBuscado != null)
            {
                comentarioBuscado.Comentario = comentariosConsulta.Comentario;
                comentarioBuscado.Situacao = comentariosConsulta.Situacao;
                comentarioBuscado.IdConsulta = comentariosConsulta.IdConsulta;
            }
            _healthContext.Update(comentarioBuscado);
            _healthContext.SaveChanges();
        }

        //**************************** CADASTRAR
        public void Cadastrar(ComentariosConsulta comentariosConsulta)
        {
            comentariosConsulta.IdComentarioConsulta = Guid.NewGuid();
            _healthContext.ComentariosConsulta.Add(comentariosConsulta);
            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            ComentariosConsulta comentarioBuscado = _healthContext.ComentariosConsulta.Find(id)!;
            _healthContext.ComentariosConsulta.Remove(comentarioBuscado);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<ComentariosConsulta> ListarTodos()
        {
            return _healthContext.ComentariosConsulta.ToList();
        }
    }
}
