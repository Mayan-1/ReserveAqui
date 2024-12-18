using ReserveAqui.Core.Models;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.ObterTodos
{
    public sealed record ObterTodasReservasMateriaisResponse
    {
        public int Id { get; set; }
        public DateOnly Data { get; set; }
        public Core.Models.Turno? Turno { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Core.Models.Material? Material { get; set; }
        public Professor? Professor { get; set; }
    }
}