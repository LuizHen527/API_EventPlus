using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {

        private readonly EventContext _eventContext;

        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do evento que sera atualizado</param>
        /// <param name="tiposEvento">Objeto com os novos dados</param>

        public void Atualizar(Guid id, TiposEvento tiposEvento)
        {
            _eventContext.TiposEvento!.Where(tipoEventoBuscado => tipoEventoBuscado.IdTiposEvento == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(tipoEventoBuscado => tipoEventoBuscado.Titulo, tiposEvento.Titulo));
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tiposEvento">Novo tipo de evento</param>

        public void Cadastrar(TiposEvento tiposEvento)
        {
            _eventContext.TiposEvento!.Add(tiposEvento);
            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que sera deletado</param>

        public void Deletar(Guid id)
        {
            _eventContext.TiposEvento.Where(tiposEvento => tiposEvento.IdTiposEvento == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Retorna uma lista com todos os tipos de evento</returns>

        public List<TiposEvento> Listar()
        {
            List<TiposEvento> tiposEvento = new List<TiposEvento>();

            var todosTiposEvento = _eventContext.TiposEvento!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todosTiposEvento != null)
            {
                foreach (var tipoEvento in todosTiposEvento)
                {
                    tiposEvento.Add(new TiposEvento()
                    {
                        IdTiposEvento = tipoEvento.IdTiposEvento,
                        Titulo = tipoEvento.Titulo
                    });
                }

                return tiposEvento;
            }


            return null!;
        }
    }
}
