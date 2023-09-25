using webapi.eventplus.Domains;

namespace webapi.eventplus.Interfaces
{

    /// <summary>
    /// Interface de instituicoes
    /// </summary>

    public interface IInstituicaoRepository
    {

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="instituicao">Nova instituicao</param>

        void Cadastrar(Instituicao instituicao);

        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Retorna uma lista com as instituicoes</returns>

        List<Instituicao> Listar();

        /// <summary>
        /// Atualiza uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao que sera atualizada</param>
        /// <param name="instituicao">Objeto com os novos dados de instituicao</param>

        void Atualizar(Guid id, Instituicao instituicao);

        /// <summary>
        /// Deleta uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao que sera deletada</param>

        void Delete(Guid id);
    }
}
