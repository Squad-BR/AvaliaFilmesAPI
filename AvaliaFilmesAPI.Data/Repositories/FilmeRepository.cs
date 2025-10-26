using AvaliaFilmesAPI.Data.Context;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using AvaliaFilmesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvaliaFilmesAPI.Data.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Filme filme)
        {
            await _context.Filmes.AddAsync(filme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var filme = await GetByIdAsync(id);
       
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Filme>> GetAllAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> GetByIdAsync(Guid id)
        {
            var filme = await _context.Filmes
                .Include(f => f.Avaliacoes)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            return filme;
        }

        public async Task UpdateAsync(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }
    }
}
