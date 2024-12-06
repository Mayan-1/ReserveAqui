using AutoMapper;

namespace ReserveAqui.Application.UseCases.Turno.Criar;

public sealed class CriarTurnoMapper : Profile
{
    public CriarTurnoMapper()
    {
        CreateMap<CriarTurnoRequest, Core.Models.Turno>();
    }
}
