namespace AvaliaFilmesAPI.Domain.Entities
{
    public class Filme
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int Nota { get; set; }
        public string Observacao { get; set; }
        public DateTime DtAnoLancamento { get; set; }
        public List<string> Marcadores { get; set; } = new List<string>();
    }
}
