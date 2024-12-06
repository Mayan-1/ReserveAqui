using AutoMapper;

namespace ReserveAqui.Application.UseCases.Material.ObterTodos;

public sealed class ObterTodosMateriaisMapper : Profile
{
    public ObterTodosMateriaisMapper()
    {
        CreateMap<Core.Models.Material, ObterTodosMateriaisResponse>();
    }
}
