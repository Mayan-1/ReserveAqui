using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterTodas;

public sealed class ObterTodasReservasSalasMapper : Profile
{
    public ObterTodasReservasSalasMapper()
    {
        CreateMap<Core.Models.ReservaSala, ObterTodasReservasSalasResponse>();
    }
}
