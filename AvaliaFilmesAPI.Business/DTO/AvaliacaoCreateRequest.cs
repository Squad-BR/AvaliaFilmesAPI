using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.DTO
{
    public class AvaliacaoCreateRequest
    {
        [Range(1, 5)]
        public int Nota { get; set; }

        public string? Comentario { get; set; }
    }
}
