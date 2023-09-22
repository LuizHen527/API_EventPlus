using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;
using webapi.eventplus.Repositories;

namespace webapi.eventplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository;

        /// <summary>
        /// Instancia um repositorio com os metodos de TiposUsuario
        /// </summary>

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario 
        /// </summary>
        /// <param name="tiposUsuario">Tipo de usuario que sera cadastrado</param>
        /// <returns>Rettorna status code 201</returns>

        [HttpPost]

        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Cadastrar(tiposUsuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">Id do tipo de usuario que sera deletado</param>
        /// <returns>Retorna status code 204</returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tiposUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera atualizado</param>
        /// <param name="tipoUsuario">Objeto com dados atualizados</param>
        /// <returns>Retorna status code 204</returns>

        [HttpPut]

        public IActionResult Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tiposUsuarioRepository.Atualizar(id, tipoUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
