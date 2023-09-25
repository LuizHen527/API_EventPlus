using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{

    /// <summary>
    /// Interface com os metodos de ComentarioEvento
    /// </summary>

    public interface IComentarioEventoRepository
    {

        /// <summary>
        /// Cadastra um comentario
        /// </summary>
        /// <param name="comentarioEvento">Novo comentario de evento</param>

        void Cadastrar(ComentarioEvento comentarioEvento);

        /// <summary>
        /// Lista todos os comentarios de evento
        /// </summary>
        /// <returns>Retorna uma lista com todos os comentarios de evento</returns>

        List<ComentarioEvento> Listar();

        /// <summary>
        /// Atualiza um comentario de evento
        /// </summary>
        /// <param name="id">Id do comentario de evento que sera atualizado</param>
        /// <param name="evento">Comentario de evento com os novos dados</param>

        void Atualizar(Guid id, ComentarioEvento comentario);

        /// <summary>
        /// Deleta um comentario de evento
        /// </summary>
        /// <param name="id">Id do comentario de evento que sera deletado</param>

        void Delete(Guid id);
    }
}
