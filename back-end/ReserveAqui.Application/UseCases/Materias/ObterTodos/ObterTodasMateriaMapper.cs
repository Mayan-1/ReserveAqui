using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Materias.ObterTodos;

public class ObterTodasMateriaMapper : Profile
{
    public ObterTodasMateriaMapper()
    {
        CreateMap<Materia, ObterTodasMateriasResponse>();
    }
}
