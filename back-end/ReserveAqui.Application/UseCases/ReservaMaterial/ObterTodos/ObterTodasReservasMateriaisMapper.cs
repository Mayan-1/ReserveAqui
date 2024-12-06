using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos;

public class ObterTodasReservasMateriaisMapper : Profile
{
    public ObterTodasReservasMateriaisMapper()
    {
        CreateMap<Core.Models.ReservaMaterial, ObterTodasReservasMateriaisResponse>();
    }
}
