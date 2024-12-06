using AutoMapper;

namespace ReserveAqui.Application.UseCases.Administrador.Criar;

public class CriarAdministradorMapper : Profile
{
    public CriarAdministradorMapper()
    {
        CreateMap<CriarAdministradorRequest, Core.Models.Administrador>()
            .ForMember(dest => dest.Instituicao, opt => opt.Ignore());
    }
}
