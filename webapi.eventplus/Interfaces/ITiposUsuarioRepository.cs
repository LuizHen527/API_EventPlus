using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{

    /// <summary>
    /// Interface de tipos de usuario
    /// </summary>
    public interface ITiposUsuarioRepository
    {

        /// <summary>
        /// Cadastra um novo Tipo de usuario
        /// </summary>
        /// <param name="TipoUsuario">Novo tipo de usuario que sera cadastrado</param>

        void Cadastrar(TiposUsuario TipoUsuario);

        /// <summary>
        /// Deleta um tipo de usuario por seu id
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>

        void Deletar(Guid id);

        /// <summary>
        /// Lista todos os tipos de usuario
        /// </summary>
        /// <returns>Retorna uma lista com todos os tipos de usuario</returns>

        List<TiposUsuario> Listar();

        /// <summary>
        /// Atualiza um tipo de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoUsuario"></param>

        void Atualizar(Guid id, TiposUsuario tipoUsuario);
    }
}
