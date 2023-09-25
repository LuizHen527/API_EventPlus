using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{
    public interface IPresencasEventoRepository
    {
        /// <summary>
        /// Cadastra uma nova presenca no evento
        /// </summary>
        /// <param name="presencasEvento">Nova presencaEvento</param>
        void Cadastrar(PresencasEvento presencasEvento);

        /// <summary>
        /// Lista todas as presenca evento
        /// </summary>
        /// <returns>Retorna uma lista com todas as presencas evento</returns>

        List<PresencasEvento> Listar();

        /// <summary>
        /// Atualiza uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera atualizada</param>
        /// <param name="presencasEvento">Objeto com os novos dados</param>

        void Atualizar(Guid id, PresencasEvento presencasEvento);

        /// <summary>
        /// Deleta uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera deletada</param>

        void Deletar(Guid id);
    }
}
