using AvaliaFilmesAPI.Business.DTO;
using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using AvaliaFilmesAPI.Domain;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IFilmeRepository _filmeRepo;
        private readonly IAvaliacaoRepository _avaliacaoRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public AvaliacaoService(
            IFilmeRepository filmeRepo,
            IAvaliacaoRepository avaliacaoRepo,
            UserManager<ApplicationUser> userManager)
        {
            _filmeRepo = filmeRepo;
            _avaliacaoRepo = avaliacaoRepo;
            _userManager = userManager;
        }

        public async Task<FilmeAvaliacaoResumoResponse> GetAvaliacoesAsync(Guid filmeId, string? userId)
        {
            var filme = await _filmeRepo.GetFilmeComAvaliacoesAsync(filmeId)
                ?? throw new Exception("Filme não encontrado.");

            var avaliacoes = filme.Avaliacoes
                .Select(a => new AvaliacaoResponse
                {
                    Id = a.Id,
                    UsuarioId = a.UserId,
                    UsuarioNome = _userManager.Users.FirstOrDefault(u => u.Id == a.UserId)?.UserName ?? "Usuário",
                    Nota = a.Nota,
                    Comentario = a.Comentario,
                    AtualizadoEm = a.AtualizadoEm
                }).ToList();

            var suaAvaliacao = userId != null
                ? filme.Avaliacoes.FirstOrDefault(a => a.UserId == userId)
                : null;

            return new FilmeAvaliacaoResumoResponse
            {
                Media = filme.NotaMedia,
                TotalAvaliacoes = filme.Avaliacoes.Count,
                SuaNota = suaAvaliacao?.Nota,
                SeuComentario = suaAvaliacao?.Comentario,
                Avaliacoes = avaliacoes
            };
        }

        public async Task<FilmeAvaliacaoResumoResponse> CreateOrUpdateAsync(Guid filmeId, string userId, AvaliacaoCreateRequest dto)
        {
            var filme = await _filmeRepo.GetFilmeComAvaliacoesAsync(filmeId)
                ?? throw new Exception("Filme não encontrado.");

            var avaliacao = await _avaliacaoRepo.GetByUserAndFilmeAsync(filmeId, userId);

            if (avaliacao == null)
            {
                avaliacao = new Avaliacao
                {
                    FilmeId = filmeId,
                    UserId = userId,
                    Nota = dto.Nota,
                    Comentario = dto.Comentario
                };
                await _avaliacaoRepo.AddAsync(avaliacao);
            }
            else
            {
                avaliacao.Nota = dto.Nota;
                avaliacao.Comentario = dto.Comentario;
                avaliacao.AtualizadoEm = DateTime.UtcNow;
                _avaliacaoRepo.Update(avaliacao);
            }

            filme.AtualizarNotaMedia();

            await _avaliacaoRepo.SaveChangesAsync();
            return await GetAvaliacoesAsync(filmeId, userId);
        }
    }

}
