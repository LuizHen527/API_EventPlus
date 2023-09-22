using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">Usuario que sera cadastrado</param>

        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Busca um usuariopor seu id
        /// </summary>
        /// <param name="id">Id do usuario que sera buscado</param>
        /// <returns>Retorna o usuario achado</returns>

        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Busca um usuario por seu email e senha
        /// </summary>
        /// <param name="email">email do usuario que sera buscado</param>
        /// <param name="senha">senha do usuario que sera buscado</param>
        /// <returns>Retorna usuario buscado</returns>

        Usuario BuscarPorEmailESenha(string email, string senha);

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="usuario">Usuario que sera deletado</param>

        void Deletar(Usuario usuario);

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera atualizado</param>
        /// <param name="usuario">Usuario com os novos dados</param>

        void Atualizar(Guid id, Usuario usuario);


    }
}
