using AvaliaFilmesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Data.Repositories.InterfaceRepository
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao?> GetByUserAndFilmeAsync(Guid filmeId, string userId);
        Task AddAsync(Avaliacao avaliacao);
        void Update(Avaliacao avaliacao);
        Task SaveChangesAsync();
    }

}
