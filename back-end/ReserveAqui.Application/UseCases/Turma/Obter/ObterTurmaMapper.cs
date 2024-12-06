using AutoMapper;

namespace ReserveAqui.Application.UseCases.Turma.Obter;

public sealed class ObterTurmaMapper : Profile
{
    public ObterTurmaMapper()
    {
        CreateMap<Core.Models.Turma, ObterTurmaResponse>();
    }
}
