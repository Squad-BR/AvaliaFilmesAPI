using AvaliaFilmesAPI.Business.DTO;
using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvaliaFilmesAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AvaliacaoController(IAvaliacaoService avaliacaoService, UserManager<ApplicationUser> userManager)
        {
            _avaliacaoService = avaliacaoService;
            _userManager = userManager;
        }

        [HttpGet("{filmeId}")]
        public async Task<IActionResult> Get(Guid filmeId)
        {
            string? userId = User.Identity?.IsAuthenticated == true
                ? _userManager.GetUserId(User)
                : null;

            var result = await _avaliacaoService.GetAvaliacoesAsync(filmeId, userId);
            return Ok(result);
        }

        [HttpPost("{filmeId}")]
        [Authorize]
        public async Task<IActionResult> Post(Guid filmeId, [FromBody] AvaliacaoCreateRequest dto)
        {
            string userId = _userManager.GetUserId(User)!;
            var result = await _avaliacaoService.CreateOrUpdateAsync(filmeId, userId, dto);

            return Ok(new
            {
                message = "Avaliacao registrada",
                media = result.Media,
                suaNota = result.SuaNota,
                seuComentario = result.SeuComentario
            });
        }
    }

}
