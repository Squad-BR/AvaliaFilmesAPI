using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliaFilmesAPI.Domain.Entities
{
    public class Filme
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Observacao { get; set; }
        public DateTime DtAnoLancamento { get; set; }
        public List<string> Marcadores { get; set; } = new List<string>();
        public ICollection<Avaliacao>? Avaliacoes { get; set; } = new List<Avaliacao>();
        public double NotaMedia { get; set; }

        public void AtualizarNotaMedia()
        {
            //if (Avaliacoes == null || !Avaliacoes.Any())
            //    return 0;

            //return Math.Round(Avaliacoes.Average(a => a.Nota), 1);

            NotaMedia = Avaliacoes != null && Avaliacoes.Any()
            ? Math.Round(Avaliacoes.Average(a => a.Nota), 1)
            : 0;
        }

    }
}
