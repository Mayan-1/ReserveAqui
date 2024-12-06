using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Turno.ObterTodos;

public class ObterTodosTurnosMapper : Profile
{
    public ObterTodosTurnosMapper()
    {
        CreateMap<Core.Models.Turno, ObterTodosTurnosResponse>();
    }
}
