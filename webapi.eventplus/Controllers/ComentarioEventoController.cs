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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }

        [HttpPost]

        public IActionResult Cadastrar(ComentarioEvento comentarioNovo)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioNovo);
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
                List<ComentarioEvento> comentarios = _comentarioEventoRepository.Listar();
                return Ok(comentarios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, ComentarioEvento comentarioAtualizado)
        {
            try
            {
                _comentarioEventoRepository.Atualizar(id, comentarioAtualizado);
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
                _comentarioEventoRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
