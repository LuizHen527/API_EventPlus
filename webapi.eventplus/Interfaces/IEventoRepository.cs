using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{
    public interface IEventoRepository
    {

        /// <summary>
        /// Cadastra um evento
        /// </summary>
        /// <param name="evento">Evento que era cadastrado</param>

        void Cadastrar(Evento evento);

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Retorna uma lista com todos os eventos</returns>

        List<Evento> Listar();

        /// <summary>
        /// Atualiza um evento
        /// </summary>
        /// <param name="id">Id do evento que sera atualizado</param>
        /// <param name="evento">Objeto com novos dados</param>

        void Atualizar(Guid id, Evento evento);

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">Id do evento que sera deletado</param>

        void Deletar(Guid id);
    }
}
