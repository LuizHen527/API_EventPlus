using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.eventplus.Contexts;
using webapi.eventplus.Domains;
using webapi.eventplus.Interfaces;
using webapi.eventplus.Repositories;

namespace webapi.eventplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Construtor que instancia o repositorio de usuario
        /// </summary>

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">Usuario que sera cadastrado</param>
        /// <returns>Retorna status code 200 se der certo</returns>

        [HttpPost]

        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>
        /// <returns>Retorna status code 200</returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {

            try
            {
                Usuario usuarioEncontrado = _usuarioRepository.BuscarPorId(id);

                _usuarioRepository.Deletar(usuarioEncontrado);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Mostra um usuario por meio de sua Id
        /// </summary>
        /// <param name="id">Id do usuario que sera buscado</param>
        /// <returns>Retorna o usuario buscado</returns>

        [HttpGet]

        public IActionResult Get(Guid id)
        {
            try
            {
                Usuario usuarioEncontrado = _usuarioRepository.BuscarPorId(id);

                return StatusCode(200, usuarioEncontrado); 
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera atualizado</param>
        /// <param name="usuario">Usuario com os novos dados</param>
        /// <returns>Retorna status code 200</returns>

        [HttpPut("atualizar")]
        
        public IActionResult Atualizar(Guid id, Usuario usuario)
        {
            try
            {

                _usuarioRepository.Atualizar(id, usuario);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
