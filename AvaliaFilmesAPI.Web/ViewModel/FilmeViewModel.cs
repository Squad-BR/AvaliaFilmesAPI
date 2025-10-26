namespace AvaliaFilmesAPI.Web.ViewModel
{
    public class FilmeDetalhesViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Observacao { get; set; }
        public int AnoLancamento { get; set; }
        public IReadOnlyCollection<string> Marcadores { get; set; }
        public double NotaMedia { get; set; }
        public int? NotaUsuarioAtual { get; set; }
    }

}
