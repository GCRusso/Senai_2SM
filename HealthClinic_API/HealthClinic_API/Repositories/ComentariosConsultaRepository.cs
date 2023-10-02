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
        /// <summary>
        /// Método que atualiza um comentario consulta
        /// </summary>
        /// <param name="id"> id consulta </param>
        /// <param name="comentariosConsulta"> lista comentarios consulta </param>
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
        /// <summary>
        /// Método que cadastra um novo comentario na consulta
        /// </summary>
        /// <param name="comentariosConsulta"> lista de comentarios consulta </param>
        public void Cadastrar(ComentariosConsulta comentariosConsulta)
        {
            comentariosConsulta.IdComentarioConsulta = Guid.NewGuid();
            _healthContext.ComentariosConsultas.Add(comentariosConsulta);
            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta um comentario da consulta pelo seu id
        /// </summary>
        /// <param name="id"> id comentario consulta </param>
        public void Deletar(Guid id)
        {
            ComentariosConsulta comentarioBuscado = _healthContext.ComentariosConsultas.Find(id)!;
            _healthContext.ComentariosConsultas.Remove(comentarioBuscado);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método que lista todos os comentários das consultas
        /// </summary>
        /// <returns> lista de comentarios </returns>
        public List<ComentariosConsulta> ListarTodos()
        {
            return _healthContext.ComentariosConsultas.ToList();
        }
    }
}
