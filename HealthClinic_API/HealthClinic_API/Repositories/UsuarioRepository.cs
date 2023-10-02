using HealthClinic_API.Contexts;
using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;
using webapi.event_.manha.Utils;

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
        /// <summary>
        /// Método para atualizar usuário
        /// </summary>
        /// <param name="id"> id de usuário </param>
        /// <param name="usuario"> lista de usuario </param>
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
        /// <summary>
        /// Método para buscar por email e senha (login)
        /// </summary>
        /// <param name="email"> email do usuario </param>
        /// <param name="senha"> senha do usuario </param>
        /// <returns></returns>
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
        /// <summary>
        /// Método para cadastrar um novo usuario
        /// </summary>
        /// <param name="usuario"> lista de usuário </param>
        public void Cadastrar(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid();
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);
            _healthContext.Usuario.Add(usuario);
            _healthContext.SaveChanges();
        }

        //**************************** DELETAR
        /// <summary>
        /// Método que deleta o usuário buscando pelo seu id
        /// </summary>
        /// <param name="id"> id de usuário </param>
        public void Deletar(Guid id)
        {
            Usuario usuario = _healthContext.Usuario.Find(id)!;
            _healthContext.Usuario.Remove(usuario);
            _healthContext.SaveChanges();
        }

        //**************************** LISTAR
        /// <summary>
        /// Método que lista todos os usuários cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Usuario> Listar()
        {
            return _healthContext.Usuario.ToList();
        }
    }
}
