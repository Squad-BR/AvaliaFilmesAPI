using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.DTO
{
    public class FilmeAvaliacaoResumoResponse
    {
        public double Media { get; set; }
        public int TotalAvaliacoes { get; set; }
        public int? SuaNota { get; set; }
        public string? SeuComentario { get; set; }
        public List<AvaliacaoResponse> Avaliacoes { get; set; } = new();
    }
}
