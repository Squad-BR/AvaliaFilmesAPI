using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using AvaliaFilmesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task AdicionarAsync(Filme filme)
        {
            await _filmeRepository.AddAsync(filme);
        }

        public async Task AtualizarAsync(Filme filme)
        {
            await _filmeRepository.UpdateAsync(filme);
        }

        public async Task<Filme> ObterPorIdAsync(Guid id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);

            return filme;
        }

        public async Task<List<Filme>> ObterTodosAsync()
        {
            return await _filmeRepository.GetAllAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            await _filmeRepository.DeleteAsync(id);
        }
    }
}
