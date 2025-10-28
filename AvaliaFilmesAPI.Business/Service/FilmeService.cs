using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;
using AvaliaFilmesAPI.Domain.Entities;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace AvaliaFilmesAPI.Business.Service
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly FilmeValidation _filmeValidator;

        public FilmeService(IFilmeRepository filmeRepository, FilmeValidation filmeValidation)
        {
            _filmeRepository = filmeRepository;
            _filmeValidator = filmeValidation;
        }

        public async Task AdicionarAsync(Filme filme)
        {
            var validationResult = await _filmeValidator.ValidateAsync(filme);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            await _filmeRepository.AddAsync(filme);
        }

        public async Task AtualizarAsync(Filme filme)
        {
            var validationResult = await _filmeValidator.ValidateAsync(filme);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }
            var filmeExistente = await _filmeRepository.GetByIdAsync(filme.Id);

            if (filmeExistente == null)
            {
                throw new ApplicationException($"Filme com Id '{filme.Id}' não encontrado.");
            }
            await _filmeRepository.UpdateAsync(filme);
        }

        public async Task<Filme> ObterPorIdAsync(Guid id)
        {
            var filme = await _filmeRepository.GetByIdAsync(id);

            if (filme == null)
            {
                throw new Exception($"Filme com Id '{id}' não encontrado.");
            }
            return filme;
        }

        public async Task<List<Filme>> ObterTodosAsync()
        {
            return await _filmeRepository.GetAllAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var filmeExistente = await _filmeRepository.GetByIdAsync(id);

            if (filmeExistente == null)
            {
                throw new ApplicationException($"Filme com Id '{id}' não encontrado.");
            }
            await _filmeRepository.DeleteAsync(id);
        }
    }
}
