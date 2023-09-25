using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{
    public interface ITiposEventoRepository
    {

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="tiposEvento">Tipo de evento que sera cadastrado</param>

        void Cadastrar(TiposEvento tiposEvento);

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Retorna uma lista com todos os tipos de evento</returns>

        List<TiposEvento> Listar();

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que sera atualizado</param>
        /// <param name="tiposEvento">Objeto com os dados atualizados</param>

        void Atualizar(Guid id, TiposEvento tiposEvento);

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que sera deletado</param>

        void Deletar(Guid id);
    }
}
