using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Instituicoes.Obter;

public class ObterInstituicaoMapper : Profile
{
    public ObterInstituicaoMapper()
    {
        CreateMap<Instituicao, ObterInstituicaoResponse>();
    }
}
