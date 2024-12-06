using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.Obter;
public sealed class ObterProfessorMapper : Profile
{
    public ObterProfessorMapper()
    {
        CreateMap<Professor, ObterProfessorResponse>();
    }
}
