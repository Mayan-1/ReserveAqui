using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaSala.Obter;

public sealed class ObterReservaSalaMapper : Profile
{
    public ObterReservaSalaMapper()
    {
        CreateMap<Core.Models.ReservaSala, ObterReservaSalaResponse>();
    }
}
