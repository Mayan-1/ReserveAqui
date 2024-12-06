using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Professores.Criar;

public class CriarProfessorMapper : Profile
{
    public CriarProfessorMapper()
    {
        CreateMap<CriarProfessorRequest, Professor>().ForMember(dest => dest.Materia, opt => opt.Ignore())
                                                     .ForMember(dest => dest.Instituicao, opt => opt.Ignore());
    }
}
