using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;

namespace HealthClinic_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;
        public UsuarioRepository()
        {
            _healthContext = new HealthContext();
        }

        //**************************** ATUALIZAR
        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = _healthContext.Usuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Nome = usuario.Nome;
            }
            _healthContext.Update(usuarioBuscado);
            _healthContext.SaveChanges();
        }

        //**************************** BUSCAR POR EMAIL E SENHA
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TiposDeUsuario = new TiposDeUsuario
                        {
                            IdTipoDeUsuario = u.IdTipoDeUsuario,
                            Titulo = u.TiposDeUsuario.Titulo,
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

        //**************************** CADASTRAR
        public void Cadastrar(Usuario usuario)
        {
            _healthContext.Usuario.Add(usuario);

            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        public void Deletar(Guid id)
        {
            Usuario usuario = _healthContext.Usuario.Find(id)!;
            _healthContext.Usuario.Remove(usuario);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        public List<Usuario> Listar()
        {
            return _healthContext.Usuario.ToList();
        }
    }
}
