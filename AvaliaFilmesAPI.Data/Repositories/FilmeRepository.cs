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
            await _context.Filme.AddAsync(filme);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                throw new Exception($"Id: {id} não encontrado!");
            }
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Filme>> GetAllAsync()
        {
            return await _context.Filme.ToListAsync();
        }

        public async Task<Filme> GetByIdAsync(Guid id)
        {
            var filme = await _context.Filme.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
            if (filme == null)
            {
                throw new Exception($"Id: {id} não encontrado!");
            }
            return filme;
        }

        public async Task UpdateAsync(Filme filme)
        {
            var FilmeExiste = await _context.Filme.AsNoTracking().FirstOrDefaultAsync(f => f.Id == filme.Id);
            if (FilmeExiste == null)
            {
                throw new Exception($"Id: {filme.Id} não encontrado!");
            }
            _context.Filme.Update(filme);
            await _context.SaveChangesAsync();
        }
    }
}
