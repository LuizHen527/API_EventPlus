using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Metodo que atualiza um usuario por meio de seu id
        /// </summary>
        /// <param name="id">Id do usuario que sera atualizado</param>
        /// <param name="usuarioAtualizado">Usuario com os dados atualizados</param>

        public void Atualizar(Guid id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = new Usuario();

            _eventContext.Usuario!.Where(usuarioBuscado => usuarioBuscado.IdUsuario == id)
                                    .ExecuteUpdateAsync(updates =>
                                         updates.SetProperty(usuarioBuscado => usuarioBuscado.Nome, usuarioAtualizado.Nome)
                                                .SetProperty(usuarioBuscado => usuarioBuscado.Email, usuarioAtualizado.Email)
                                                .SetProperty(usuarioBuscado => usuarioBuscado.Senha, usuarioAtualizado.Senha)
                                                .SetProperty(usuarioBuscado => usuarioBuscado.IdTipoUsuario, usuarioAtualizado.IdTipoUsuario));
        }

        /// <summary>
        /// Busca um usuario por seu email e senha
        /// </summary>
        /// <param name="email">Email do usuario que sera buscado</param>
        /// <param name="senha">Senha do usuario que sera buscado</param>
        /// <returns>Retorna usuario buscado ou null se nao achou</returns>

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

        /// <summary>
        /// Busca um usuario por seu id
        /// </summary>
        /// <param name="id">Id do usuario que sera buscado</param>
        /// <returns>Retorna usuario buscado</returns>

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

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Usuario que sera cadastrado</param>

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

            _eventContext.Usuario!.Add(usuario);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="usuario">Usuario que sera deletado</param>

        public void Deletar(Usuario usuario)
        {
            _eventContext.Usuario!.Remove(usuario);

            _eventContext.SaveChanges();
        }
    }
}
