using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service
{
    public class Validation
    {
        public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }

        public class ValidationException : Exception
        {
            public Dictionary<string, List<string>> Errors { get; }

            public ValidationException(Dictionary<string, List<string>> errors)
                : base("Erro de validação")
            {
                Errors = errors;
            }
        }
    }
}
