using AutoMapper;

namespace ReserveAqui.Application.UseCases.Administrador.ObterTodos;

public class ObterTodosAdministradoresMapper : Profile
{
    public ObterTodosAdministradoresMapper()
    {
        CreateMap<Core.Models.Administrador, ObterTodosAdministradoresResponse>();
    }
}
