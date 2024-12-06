using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.Atualizar;

public class AtualizarProfessorMapper : Profile
{
    public AtualizarProfessorMapper()
    {
        CreateMap<Professor, AtualizarProfessorRequest>().ForMember(dest => dest.Materia, opt => opt.Ignore())
                                                     .ForMember(dest => dest.Instituicao, opt => opt.Ignore());
    }
}
