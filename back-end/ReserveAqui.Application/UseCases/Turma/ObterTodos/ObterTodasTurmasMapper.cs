using AutoMapper;

namespace ReserveAqui.Application.UseCases.Turma.ObterTodos;

public sealed class ObterTodasTurmasMapper : Profile
{
    public ObterTodasTurmasMapper()
    {
        CreateMap<Core.Models.Turma, ObterTodasTurmasResponse>();
    }
}
