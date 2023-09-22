using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Utils;

namespace webapi.event_.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventoContext _eventoContext;

        public UsuarioRepository()
        {
            _eventoContext = new EventoContext();
        }

        //******************* ATUALIZAR
        public void Atualizar(Guid id, UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _eventoContext.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
            }
            _eventoContext.Update(usuarioBuscado);
            _eventoContext.SaveChanges();
        }




        //********************* BUSCAR POR EMAIL E SENHA
        public UsuarioDomain BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _eventoContext.Usuario
                    .Select(u => new UsuarioDomain
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TiposUsuario = new TiposUsuarioDomain
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario.Titulo,
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);
                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //********************* BUSCAR POR ID
        public UsuarioDomain BuscarPorId(Guid id)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _eventoContext.Usuario.FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //******************* CADASTRAR
        public void Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventoContext.Usuario.Add(usuario);

                _eventoContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //******************* DELETAR
        public void Deletar(Guid id)
        {
            UsuarioDomain usuario = _eventoContext.Usuario.Find(id)!;
            _eventoContext.Usuario.Remove(usuario);
            _eventoContext.SaveChanges();
        }


        //******************* LISTAR
        public List<UsuarioDomain> Listar()
        {
            return _eventoContext.Usuario.ToList();
        }
    }
}
