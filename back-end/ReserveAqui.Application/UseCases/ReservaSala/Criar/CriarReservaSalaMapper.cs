using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaSala.Criar;

public sealed class CriarReservaSalaMapper : Profile
{
    public CriarReservaSalaMapper()
    {
        CreateMap<CriarReservaSalaRequest, Core.Models.ReservaSala>()
            .ForMember(dest => dest.Sala, opt => opt.Ignore())
            .ForMember(dest => dest.Professor, opt => opt.Ignore())
            .ForMember(dest => dest.Turno, opt => opt.Ignore());
    }
}
