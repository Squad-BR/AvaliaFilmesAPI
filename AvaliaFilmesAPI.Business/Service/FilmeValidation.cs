using AvaliaFilmesAPI.Domain.Entities;
using FluentValidation;

namespace AvaliaFilmesAPI.Business.Service
{
    public class FilmeValidation : AbstractValidator<Filme>
    {
        public FilmeValidation()
        {
            RuleFor(filme => filme.Titulo)
                .NotEmpty().WithMessage("O título do filme é obrigatório.")
                .Length(2, 200).WithMessage("O título deve ter entre 2 e 200 caracteres.");

            RuleFor(filme => filme.DtAnoLancamento)
                .NotEmpty().WithMessage("A data de lançamento é obrigatória.")
                .Must(dt => dt.Year >= 1895).WithMessage("A data de lançamento deve ser em ou após 1895.")
                .LessThanOrEqualTo(DateTime.Now.Date).WithMessage("A data de lançamento não pode ser futura.");

            RuleFor(filme => filme.Observacao)
                .MaximumLength(600).WithMessage("A observação não pode exceder 600 caracteres.")
                .When(filme => !string.IsNullOrEmpty(filme.Observacao));

            RuleFor(filme => filme.Marcadores)
                .NotNull().WithMessage("A lista de marcadores não deve ser nula.")
                .Must(list => list.Count <= 10).WithMessage("Um filme pode ter no máximo 10 marcadores.");
        }
    }
}