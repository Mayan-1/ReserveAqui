using AutoMapper;

namespace ReserveAqui.Application.UseCases.Turma.Criar;

public sealed class CriarTurmaMapper : Profile
{
    public CriarTurmaMapper()
    {
        CreateMap<CriarTurmaRequest, Core.Models.Turma>()
            .ForMember(dest => dest.Turno, opt => opt.Ignore());
    }
}
