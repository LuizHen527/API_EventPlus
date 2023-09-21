using Microsoft.AspNetCore.Http.HttpResults;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;
using webapi.eventplus.Utils;
using webapi.eventplus.ViewModel;

namespace webapi.eventplus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            usuario.IdUsuario = usuarioBuscado.IdUsuario;
            usuario.Email = usuarioBuscado.Email;
            usuario.Nome = usuarioBuscado.Nome;
            usuario.IdTipoUsuario = usuarioBuscado.IdTipoUsuario;
            usuario.Senha = usuarioBuscado.Senha;

            _eventContext.Update(usuario);

            _eventContext.SaveChanges();

        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario!
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if(confere)
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

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario!
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email= u.Email,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario= u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if(usuarioBuscado != null)
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

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

            _eventContext.Usuario!.Add(usuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            _eventContext.Usuario!.Remove(usuario);

            _eventContext.SaveChanges();
        }
    }
}
