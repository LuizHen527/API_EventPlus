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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="instituicao">Nova instituicao</param>

        [HttpPost]

        public IActionResult Cadastrar(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao</param>
        /// <param name="instituicao">Novos dados</param>

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todas as instituicoes
        /// </summary>
        /// <returns>Retorna lista com instituicoes</returns>

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<Instituicao> instituicoes = new List<Instituicao> ();
                instituicoes = _instituicaoRepository.Listar();
                return StatusCode(200, instituicoes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma instituicao
        /// </summary>
        /// <param name="id">Id da instituicao que sera deletada</param>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _instituicaoRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
