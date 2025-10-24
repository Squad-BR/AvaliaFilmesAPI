using AvaliaFilmesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Data.Repositories.InterfaceRepository
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> GetAllAsync();
        Task<Filme> GetByIdAsync(Guid id);
        Task AddAsync(Filme filme);
        Task UpdateAsync(Filme filme);
        Task DeleteAsync(Guid id);
    }
}
