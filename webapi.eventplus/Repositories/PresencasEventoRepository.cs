using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
             _eventContext = new EventContext();
        }

        /// <summary>
        /// Atualiza uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera atualizada</param>
        /// <param name="presencasEvento">Objeto com os novos dados</param>

        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento!.Where(p => p.IdPresencasEvento == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(p => p.Situacao, presencasEvento.Situacao)
                           .SetProperty(p => p.IdEvento, presencasEvento.IdEvento)
                           .SetProperty(p => p.IdUsuario, presencasEvento.IdUsuario));
        }

        /// <summary>
        /// Cadastra uma nova presenca no evento
        /// </summary>
        /// <param name="presencasEvento">Nova presencaEvento</param>

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento!.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera deletada</param>

        public void Deletar(Guid id)
        {
            _eventContext.PresencasEvento!.Where(p => p.IdPresencasEvento == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todas as presenca evento
        /// </summary>
        /// <returns>Retorna uma lista com todas as presencas evento</returns>

        public List<PresencasEvento> Listar()
        {
            List<PresencasEvento> presencasEvento = new List<PresencasEvento>();

            var todasPresencasEvento = _eventContext.PresencasEvento!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todasPresencasEvento != null)
            {
                foreach (var presencaEvento in todasPresencasEvento)
                {
                    presencasEvento.Add(new PresencasEvento()
                    {
                        IdPresencasEvento = presencaEvento.IdPresencasEvento,
                        Situacao = presencaEvento.Situacao,
                        IdUsuario = presencaEvento.IdUsuario,
                        IdEvento = presencaEvento.IdEvento,
                    });
                }

                return presencasEvento;
            }


            return null!;
        }
    }
}
