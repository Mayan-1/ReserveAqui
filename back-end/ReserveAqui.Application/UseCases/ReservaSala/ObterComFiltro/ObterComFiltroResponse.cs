using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.ReservaSala.ObterComFiltro
{
    public sealed record ObterComFiltroResponse
    {
        public DateOnly Data { get; set; }
    }
}