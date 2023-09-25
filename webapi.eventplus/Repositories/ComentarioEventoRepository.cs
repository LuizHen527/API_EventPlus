using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, ComentarioEvento comentario)
        {
            _eventContext.ComentarioEvento!.Where(c => c.IdComentarioEvento == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(c => c.Descricao, comentario.Descricao)
                           .SetProperty(c => c.Exibe, comentario.Exibe)
                           .SetProperty(c => c.IdUsuario, comentario.IdUsuario)
                           .SetProperty(c => c.IdEvento, comentario.IdEvento));
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            _eventContext.ComentarioEvento!.Add(comentarioEvento);

            _eventContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _eventContext.ComentarioEvento!.Where(c => c.IdComentarioEvento == id)
                .ExecuteDeleteAsync();
        }

        public List<ComentarioEvento> Listar()
        {
            List<ComentarioEvento> comentarios = new List<ComentarioEvento>();

            var todosComentarios = _eventContext.ComentarioEvento!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todosComentarios != null)
            {
                foreach (var comentario in todosComentarios)
                {
                    comentarios.Add(new ComentarioEvento()
                    {
                        IdComentarioEvento = comentario.IdComentarioEvento,
                        Descricao = comentario.Descricao,
                        Exibe = comentario.Exibe,
                        IdUsuario = comentario.IdUsuario,
                        IdEvento = comentario.IdEvento,
                    });
                }

                return comentarios;
            }


            return null!;
        }
    }
}
