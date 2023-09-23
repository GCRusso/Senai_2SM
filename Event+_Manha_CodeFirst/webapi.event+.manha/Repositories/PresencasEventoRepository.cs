using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventoContext _eventoContext;

        public PresencasEventoRepository()
        {
            _eventoContext = new EventoContext();
        }

        //**************************** ATUALIZAR
        public void Atualizar(Guid id, PresencasEventoDomain presencasEvento)
        {
            try
            {
                PresencasEventoDomain presencaBuscada = _eventoContext.PresencasEvento.FirstOrDefault(z => z.IdPresencasEvento == id)!;

                if (presencaBuscada != null)
                {
                    presencaBuscada.Situacao = presencasEvento.Situacao;
                    presencaBuscada.IdEvento = presencasEvento.IdEvento;
                    presencaBuscada.IdUsuario = presencasEvento.IdUsuario;

                    _eventoContext.PresencasEvento.Update(presencaBuscada);
                    _eventoContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** CADASTRAR
        public void Cadastrar(PresencasEventoDomain presencasEvento)
        {
            try
            {
                _eventoContext.PresencasEvento.Add(presencasEvento);
                _eventoContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** DELETAR
        public void Delete(Guid id)
        {
            try
            {
                PresencasEventoDomain eventoDeletado = _eventoContext.PresencasEvento.FirstOrDefault(z => z.IdPresencasEvento == id)!;
                _eventoContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //**************************** LISTAR
        public List<PresencasEventoDomain> Listar()
        {
            return _eventoContext.PresencasEvento.ToList();
        }

        //**************************** LISTAR MINHAS PRESENÇAS
        public List<PresencasEventoDomain> ListarPresenca(Guid id)
        {
            try
            {

                return _eventoContext.PresencasEvento.Where(z => z.IdUsuario == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
