using AvaliaFilmesAPI.Data.Context;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Avaliacao?> GetByUserAndFilmeAsync(Guid filmeId, string userId)
        {
            return await _context.Avaliacoes
                .FirstOrDefaultAsync(a => a.FilmeId == filmeId && a.UserId == userId);
        }

        public async Task AddAsync(Avaliacao avaliacao)
        {
            await _context.Avaliacoes.AddAsync(avaliacao);
        }

        public void Update(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Update(avaliacao);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
