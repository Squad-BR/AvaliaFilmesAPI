using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service.Interface
{
    public interface IDescricaoFilmeGemini
    {
        Task<string> GenerateTextFromTextInput(string prompt);
    }
}
