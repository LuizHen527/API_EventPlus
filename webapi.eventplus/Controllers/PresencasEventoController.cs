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
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;

        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }

        /// <summary>
        /// Cadastra uma nova presenca no evento
        /// </summary>
        /// <param name="presencasEvento">Nova presencaEvento</param>

        [HttpPost]

        public IActionResult Cadastrar(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as presenca evento
        /// </summary>
        /// <returns>Retorna uma lista com todas as presencas evento</returns>

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<PresencasEvento> todasPresencas = _presencasEventoRepository.Listar();

                return Ok(todasPresencas);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera deletada</param>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _presencasEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma presenca evento
        /// </summary>
        /// <param name="id">Id da presenca evento que sera atualizada</param>
        /// <param name="presencasEvento">Objeto com os novos dados</param>

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, PresencasEvento novaPresencaEvento)
        {
            try
            {
                _presencasEventoRepository.Atualizar(id, novaPresencaEvento);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
