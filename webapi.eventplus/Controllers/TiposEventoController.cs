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
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tiposEvento">Novo tipo de evento</param>

        [HttpPost]

        public IActionResult Cadastrar(TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os tipos de evento
        /// </summary>
        /// <returns>Retorna uma lista com todos os tipos de evento</returns>

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<TiposEvento> tiposEvento = _tiposEventoRepository.Listar();

                return Ok(tiposEvento);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="id">Id do evento que sera atualizado</param>
        /// <param name="tiposEvento">Objeto com os novos dados</param>

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tipoEvento);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">Id do tipo de evento que sera deletado</param>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
