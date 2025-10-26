using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliaFilmesAPI.Domain.Entities
{
    public sealed class Avaliacao
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FilmeId { get; set; }

        [ForeignKey(nameof(FilmeId))]
        public Filme Filme { get; set; } = default!;

        [Required]
        public string UserId { get; set; } = default!; // Identity FK

        [ForeignKey(nameof(UserId))]
        public ApplicationUser Usuario { get; set; } = default!;

        [Range(1, 5)]
        public int Nota { get; set; }

        public string? Comentario { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
    }
}
