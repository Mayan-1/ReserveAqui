
using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterComFiltro;

public class ObterReservaMaterialComFiltroMapper : Profile
{
    public ObterReservaMaterialComFiltroMapper()
    {
        CreateMap<Core.Models.ReservaMaterial, ObterReservaMaterialComFiltroResponse>();
    }
}
