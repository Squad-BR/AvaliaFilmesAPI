using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AvaliaFilmesAPI.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var filmes = await _filmeService.ObterTodosAsync();
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var filme = await _filmeService.ObterPorIdAsync(id);
            if (filme == null)
            {
                return NotFound($"ID: {id} não encontrado!.");
            }

            return Ok(filme);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _filmeService.AdicionarAsync(filme);
            return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Filme filme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var filmeExistente = await _filmeService.ObterPorIdAsync(id);
            if (filmeExistente == null)
            {
                return NotFound($"ID: {id} não encontrado!.");
            }
            
            await _filmeService.AtualizarAsync(filme);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var filmeExistente = await _filmeService.ObterPorIdAsync(id);
            if (filmeExistente == null)
            {
                return NotFound($"ID: {id} não encontrado!.");
            }
            await _filmeService.RemoverAsync(id);
            return NoContent();
        }

    }
}
