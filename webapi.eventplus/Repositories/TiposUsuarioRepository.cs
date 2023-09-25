using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;

namespace webapi.eventplus.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Intancia a context
        /// </summary>

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Atualiza um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario que sera atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com os novos dados</param>

        public void Atualizar(Guid id, TiposUsuario tipoUsuarioAtualizado)
        {

            _eventContext.TiposUsuario!.Where(tipoUsuarioBuscado => tipoUsuarioBuscado.IdTipoUsuario == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(tipoUsuarioBuscado => tipoUsuarioBuscado.Titulo, tipoUsuarioAtualizado.Titulo));
        }

        /// <summary>
        /// Cadastra um novo Tipo de usuario
        /// </summary>
        /// <param name="TipoUsuario">Novo tipo de usuario que sera cadastrado</param>

        public void Cadastrar(TiposUsuario TipoUsuario)
        {
            _eventContext.TiposUsuario?.Add(TipoUsuario);

            _eventContext.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuario por seu id
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>

        public void Deletar(Guid id)
        {
            //TiposUsuario tiposUsuario = new TiposUsuario();

            _eventContext.TiposUsuario!.Where(tiposUsuario => tiposUsuario.IdTipoUsuario == id)
                .ExecuteDeleteAsync();  
        }

        /// <summary>
        /// Lista todos os tipos de usuario
        /// </summary>
        /// <returns>Retorna uma lista com todos os tipos de usuario</returns>

        public List<TiposUsuario> Listar()
        {
            List<TiposUsuario> tiposUsuarios = new List<TiposUsuario>();

            var todosTiposUsuario = _eventContext.TiposUsuario!.ToList();

            //var existeObjeto = _eventContext.TiposUsuario.SingleOrDefault();

            if (todosTiposUsuario != null)
            {
                foreach (var TipoUsuario in todosTiposUsuario)
                {
                    tiposUsuarios.Add(new TiposUsuario()
                    {
                        IdTipoUsuario = TipoUsuario.IdTipoUsuario,
                        Titulo = TipoUsuario.Titulo
                    });
                }

                return tiposUsuarios;
            }


            return null!;

        }
    }
}
