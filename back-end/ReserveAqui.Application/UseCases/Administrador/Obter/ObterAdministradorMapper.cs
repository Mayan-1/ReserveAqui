using AutoMapper;

namespace ReserveAqui.Application.UseCases.Administrador.Obter;

public sealed class ObterAdministradorMapper : Profile
{
    public ObterAdministradorMapper()
    {
        CreateMap<Core.Models.Administrador, ObterAdministradorResponse>();
    }
}
