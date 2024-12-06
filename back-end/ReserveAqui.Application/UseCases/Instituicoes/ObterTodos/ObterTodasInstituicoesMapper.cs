using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Instituicoes.ObterTodos;

public class ObterTodasInstituicoesMapper : Profile
{
    public ObterTodasInstituicoesMapper()
    {
        CreateMap<Instituicao, ObterTodasInstituicoesResponse>();
    }
}
