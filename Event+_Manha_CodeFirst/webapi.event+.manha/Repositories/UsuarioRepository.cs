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

    public UsuarioDomain BuscarPorEmailESenha(string email, string senha)
    {
            try
            {
                UsuarioDomain usuarioBuscado = _eventoContext.Usuario.FirstOrDefault(u => u.Email == email)!;

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

    public UsuarioDomain BuscarPorId(Guid id)
    {
            try
            {
                UsuarioDomain usuarioBuscado = _eventoContext.Usuario
                    .Select(u => new UsuarioDomain
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        
                        TiposUsuario = new TiposUsuarioDomain
                        {
                            IdTipoUsuario= u.IdTipoUsuario,
                            Titulo = u.TiposUsuario.Titulo,
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

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
}
}
