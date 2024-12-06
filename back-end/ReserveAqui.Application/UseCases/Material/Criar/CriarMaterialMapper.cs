using AutoMapper;

namespace ReserveAqui.Application.UseCases.Material.Criar;

public class CriarMaterialMapper : Profile
{
    public CriarMaterialMapper()
    {
        CreateMap<CriarMaterialRequest, Core.Models.Material>();
    }
}

