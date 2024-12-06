using AutoMapper;

namespace ReserveAqui.Application.UseCases.Material.Atualizar;

public class AtualizarMaterialMapper : Profile
{
    public AtualizarMaterialMapper()
    {
        CreateMap<AtualizarMaterialRequest, Core.Models.Material>();
    }
}
