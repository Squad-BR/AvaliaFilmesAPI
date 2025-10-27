using System.ComponentModel.DataAnnotations;

namespace AvaliaFilmesAPI.Domain.Entities
{
    public class Avaliacao
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid FilmeId { get; set; }

        [Required]
        public string UserId { get; set; } = default!; // Identity FK

        [Range(1, 5)]
        public int Nota { get; set; }

        public string? Comentario { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
    }
}
