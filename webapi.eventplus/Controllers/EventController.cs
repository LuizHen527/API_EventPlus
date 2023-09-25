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
    public class EventController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpPost]

        public IActionResult Cadastrar(Evento eventoNovo)
        {
            try
            {
                _eventoRepository.Cadastrar(eventoNovo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<Evento> todosEventos = _eventoRepository.Listar();

                return Ok(todosEventos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, Evento eventoNovo)
        {
            try
            {
                _eventoRepository.Atualizar(id, eventoNovo);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
