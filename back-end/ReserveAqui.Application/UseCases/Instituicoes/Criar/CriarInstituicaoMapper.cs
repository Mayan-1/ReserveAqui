using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Instituicoes.Criar;

public class CriarInstituicaoMapper : Profile
{
    public CriarInstituicaoMapper()
    {
        CreateMap<CriarInstituicaoRequest, Instituicao>();
    }
}
