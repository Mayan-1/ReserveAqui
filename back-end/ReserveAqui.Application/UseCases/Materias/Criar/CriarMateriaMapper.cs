using AutoMapper;
using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.Materias.Criar;

public class CriarMateriaMapper : Profile
{
    public CriarMateriaMapper()
    {
        CreateMap<CriaMateriaRequest, Materia>();
    }
}
