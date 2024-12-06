using AutoMapper;

namespace ReserveAqui.Application.UseCases.Sala.Obter;

public class ObterSalaMapper : Profile
{
    public ObterSalaMapper()
    {
        CreateMap<Core.Models.Sala, ObterSalaResponse>();
    }
}
