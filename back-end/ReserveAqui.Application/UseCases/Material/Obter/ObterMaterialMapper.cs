using AutoMapper;

namespace ReserveAqui.Application.UseCases.Material.Obter;

public class ObterMaterialMapper : Profile
{
    public ObterMaterialMapper()
    {
        CreateMap<Core.Models.Material, ObterMaterialResponse>();
    }
}
