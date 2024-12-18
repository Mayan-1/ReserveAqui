
using AutoMapper;
using ReserveAqui.Application.UseCases.Professores.Atualizar;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Administrador.Atualizar;

public class AtualizarAdministradorMapper : Profile
{
    public AtualizarAdministradorMapper()
    {
        CreateMap<Core.Models.Administrador, AtualizarAdministradorRequest>();
    }
}
