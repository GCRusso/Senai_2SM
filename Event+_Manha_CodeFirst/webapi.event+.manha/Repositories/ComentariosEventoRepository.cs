using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly EventoContext _eventoContext;
        public ComentariosEventoRepository()
        {
            _eventoContext = new EventoContext();
        }

        //**************************** ATUALIZAR
        public void Atualizar(Guid id, ComentariosEventoDomain comentariosEvento)
        {
            ComentariosEventoDomain comentarioBuscado = _eventoContext.ComentariosEvento.Find(id)!;

            if (comentarioBuscado != null)
            {
                comentarioBuscado.IdUsuario = comentariosEvento.IdUsuario;
                comentarioBuscado.IdEvento = comentariosEvento.IdEvento;
                comentarioBuscado.Descricao = comentariosEvento.Descricao;
                comentarioBuscado.Exibe = comentariosEvento.Exibe;
            }
            _eventoContext.Update(comentarioBuscado);
            _eventoContext.SaveChanges();
        }

        //**************************** BUSCAR POR ID
        public ComentariosEventoDomain BuscarPorId(Guid id)
        {
            try
            {
                ComentariosEventoDomain comentarioBuscado = _eventoContext.ComentariosEvento
                    .Select(u => new ComentariosEventoDomain
                    {
                        IdComentarioEvento = u.IdComentarioEvento,
                        Descricao = u.Descricao,
                        IdEvento = u.IdEvento,

                    }).FirstOrDefault(u => u.IdComentarioEvento == id)!;

                if (comentarioBuscado!= null)
                {
                    return comentarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** CADASTRAR
        public void Cadastrar(ComentariosEventoDomain comentariosEvento)
        {
            _eventoContext.ComentariosEvento.Add(comentariosEvento);

            _eventoContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            ComentariosEventoDomain comentariosEvento = _eventoContext.ComentariosEvento.Find(id)!;
            _eventoContext.ComentariosEvento.Remove(comentariosEvento);
            _eventoContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<ComentariosEventoDomain> Listar()
        {
            return _eventoContext.ComentariosEvento.ToList();
        }
    }
}
