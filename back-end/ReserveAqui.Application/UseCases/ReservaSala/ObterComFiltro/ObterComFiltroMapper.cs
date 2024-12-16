
using AutoMapper;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro;

public class ObterComFiltroMapper : Profile
{
    public ObterComFiltroMapper()
    {
        CreateMap<Core.Models.ReservaSala, ObterComFiltroResponse>();
    }
}
