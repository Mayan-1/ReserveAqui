using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Criar;

public sealed class CriarReservaMaterialMapper : Profile
{
    public CriarReservaMaterialMapper()
    {
        CreateMap<CriarReservaMaterialRequest, Core.Models.ReservaMaterial>()
            .ForMember(dest => dest.Material, opt => opt.Ignore())
            .ForMember(dest => dest.Professor, opt => opt.Ignore())
            .ForMember(dest => dest.Turno, opt => opt.Ignore());
    }
}
