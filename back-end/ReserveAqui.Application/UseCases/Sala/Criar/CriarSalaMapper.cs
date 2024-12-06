using AutoMapper;

namespace ReserveAqui.Application.UseCases.Sala.Criar;

public class CriarSalaMapper : Profile
{
    public CriarSalaMapper()
    {
        CreateMap<CriarSalaRequest, Core.Models.Sala>();
    }
}
