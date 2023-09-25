using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{

    /// <summary>
    /// Classe com os metodos de Instituicao
    /// </summary>

    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Atualiza uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <param name="instituicao">Novos dados</param>

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            _eventContext.Instituicao!.Where(instituicaoBuscada => instituicaoBuscada.IdInstituicao == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(instituicaoBuscada => instituicaoBuscada.CNPJ, instituicao.CNPJ)
                           .SetProperty(instituicaoBuscada => instituicaoBuscada.NomeFantasia, instituicao.NomeFantasia)
                           .SetProperty(instituicaoBuscada => instituicaoBuscada.Endereco, instituicao.Endereco));
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="instituicao">Nova instituicao</param>

        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao?.Add(instituicao);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao que sera deletada</param>

        public void Delete(Guid id)
        {
            _eventContext.Instituicao!.Where(Instituicao => Instituicao.IdInstituicao == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Retorna lista com instituicoes</returns>

        public List<Instituicao> Listar()
        {
            List<Instituicao> instituicoes = new List<Instituicao>();

            var todasInstituicoes = _eventContext.Instituicao!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todasInstituicoes != null)
            {
                foreach (var instituicao in todasInstituicoes)
                {
                    instituicoes.Add(new Instituicao()
                    {
                        IdInstituicao = instituicao.IdInstituicao,
                        CNPJ = instituicao.CNPJ,
                        Endereco = instituicao.Endereco,
                        NomeFantasia = instituicao.NomeFantasia
                    });
                }

                return instituicoes;
            }


            return null!;
        }
    }
}
