using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Obter;

public sealed class ObterReservaMaterialMapper : Profile
{
    public ObterReservaMaterialMapper()
    {
        CreateMap<Core.Models.ReservaMaterial, ObterReservaMaterialResponse>();
    }
}
