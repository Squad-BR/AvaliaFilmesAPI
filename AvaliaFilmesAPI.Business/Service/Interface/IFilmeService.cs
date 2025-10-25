using AvaliaFilmesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service.Interface
{
    public interface IFilmeService
    {
        Task<List<Filme>> ObterTodosAsync();
        Task<Filme> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Filme filme);
        Task AtualizarAsync(Filme filme);
        Task RemoverAsync(Guid id);
    }
}
