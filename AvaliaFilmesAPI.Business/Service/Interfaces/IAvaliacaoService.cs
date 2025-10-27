using AvaliaFilmesAPI.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliaFilmesAPI.Business.Service.Interface
{
    public interface IAvaliacaoService
    {
        Task<FilmeAvaliacaoResumoResponse> GetAvaliacoesAsync(Guid filmeId, string? userId);
        Task<FilmeAvaliacaoResumoResponse> CreateOrUpdateAsync(Guid filmeId, string userId, AvaliacaoCreateRequest dto);
    }


}
