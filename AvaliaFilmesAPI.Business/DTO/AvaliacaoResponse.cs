using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.DTO
{
    public class AvaliacaoResponse
    {
        public Guid Id { get; set; }
        public string UsuarioId { get; set; } = default!;
        public string UsuarioNome { get; set; } = default!;
        public int Nota { get; set; }
        public string? Comentario { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
