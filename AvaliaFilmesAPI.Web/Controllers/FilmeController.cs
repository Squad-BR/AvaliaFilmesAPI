using AvaliaFilmesAPI.Business.Service;
using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static AvaliaFilmesAPI.Business.Service.Validation;

namespace AvaliaFilmesAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        private readonly IDescricaoFilmeGemini _geminiService;

        public FilmeController(IFilmeService filmeService, IDescricaoFilmeGemini geminiService)
        {
            _filmeService = filmeService;
            _geminiService = geminiService;
        }

        [HttpGet("todos-filmes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var filmes = await _filmeService.ObterTodosAsync();
            return Ok(filmes);
        }

        [HttpGet("filme/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {

            try
            {
                var filme = await _filmeService.ObterPorIdAsync(id);
                return Ok(filme);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        [HttpPost("adicionar-filme")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _filmeService.AdicionarAsync(filme);
            return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
        }

        [HttpPut("editar-filme/{id}")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] Filme filme)
        {

            try
            {
                await _filmeService.AtualizarAsync(filme);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("excluir-filme/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            try
            {
                await _filmeService.RemoverAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("gerar-descricao")]
        public async Task<IActionResult> GerarDescricao(string titulo)
        {
            var prompt = $"Me dê uma sinopse cativante e curta para o filme: {titulo}, gere a sinopse diretamente, sem introdução";
            var descricao = await _geminiService.GenerateTextFromTextInput(prompt);

            return Ok(new { Titulo = titulo, DescricaoIA = descricao });
        }

    }
}
