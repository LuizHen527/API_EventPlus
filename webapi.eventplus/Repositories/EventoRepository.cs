using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
             _eventContext = new EventContext();
        }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">Id do evento que sera deletado</param>

        public void Atualizar(Guid id, Evento evento)
        {
            _eventContext.Evento!.Where(eventoBuscado => eventoBuscado.IdEvento == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(eventoBuscado => eventoBuscado.DataEvento, evento.DataEvento)
                           .SetProperty(eventoBuscado => eventoBuscado.NomeEvento, evento.NomeEvento)
                           .SetProperty(eventoBuscado => eventoBuscado.Descricao, evento.Descricao)
                           .SetProperty(eventoBuscado => eventoBuscado.IdTipoEvento, evento.IdTipoEvento)
                           .SetProperty(eventoBuscado => eventoBuscado.IdInstituicao, evento.IdInstituicao));
        }

        /// <summary>
        /// Cadastra um evento
        /// </summary>
        /// <param name="evento">Evento que era cadastrado</param>

        public void Cadastrar(Evento evento)
        {
            _eventContext.Add(evento);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta um evento
        /// </summary>
        /// <param name="id">Id do evento que sera deletado</param>

        public void Deletar(Guid id)
        {
            _eventContext.Evento.Where(evento => evento.IdEvento == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Retorna uma lista com todos os eventos</returns>

        public List<Evento> Listar()
        {
            List<Evento> tiposEvento = new List<Evento>();

            var todosEventos = _eventContext.Evento!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todosEventos != null)
            {
                foreach (var tipoEvento in todosEventos)
                {
                    tiposEvento.Add(new Evento()
                    {
                        IdEvento = tipoEvento.IdEvento,

                        DataEvento = tipoEvento.DataEvento,

                        NomeEvento = tipoEvento.NomeEvento,

                        Descricao = tipoEvento.Descricao,

                        IdTipoEvento = tipoEvento.IdTipoEvento,

                        IdInstituicao = tipoEvento.IdInstituicao
                    });
                }

                return tiposEvento;
            }


            return null!;
        }
    }
}
