using AutoMapper;

namespace ReserveAqui.Application.UseCases.Sala.ObterTodos;

public class ObterTodasSalasMapper : Profile
{
    public ObterTodasSalasMapper()
    {
        CreateMap<Core.Models.Sala, ObterTodasSalasResponse>();
    }
}
