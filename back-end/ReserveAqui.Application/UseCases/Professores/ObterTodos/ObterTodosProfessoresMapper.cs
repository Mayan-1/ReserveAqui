using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.ObterTodos;

public class ObterTodosProfessoresMapper : Profile
{
    public ObterTodosProfessoresMapper()
    {
        CreateMap<Professor, ObterTodosProfessoresResponse>();
    }
}
