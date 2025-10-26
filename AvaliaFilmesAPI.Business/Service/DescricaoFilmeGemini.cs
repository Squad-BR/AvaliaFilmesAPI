using AvaliaFilmesAPI.Business.Service.Interface;
using Google.GenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service
{
    public class DescricaoFilmeGemini : IDescricaoFilmeGemini
    {
        private readonly Client _client;

        public DescricaoFilmeGemini(Client client)
        {
            _client = client;
        }

        public async Task<string> GenerateTextFromTextInput(string prompt)
        {
            var response = await _client.Models.GenerateContentAsync(
                model: "gemini-2.5-flash",
                contents: prompt);

            var firstCandidate = response.Candidates.FirstOrDefault();

            if (firstCandidate != null && firstCandidate.Content?.Parts?.Any() == true)
            {
                var textPart = firstCandidate.Content.Parts[0].Text;

                if (!string.IsNullOrEmpty(textPart))
                {
                    return textPart;
                }
            }

            return "Falha ao gerar o texto (resposta do modelo vazia ou bloqueada).";
        }
    }
}
