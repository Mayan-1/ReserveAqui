using MediatR;
using ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.ReservaSalaRepository;

namespace ReserveAqui.Application.UseCases.ReservaSala.Deletar;

public sealed class DeletarReservaSalaHandler : IRequestHandler<DeletarReservaSalaRequest, DeletarReservaSalaResponse>
{
    private readonly IReservaSalaRepository _reservaSalaRepository;
    private readonly IUnitOfWork _uof;

    public DeletarReservaSalaHandler(IReservaSalaRepository reservaSalaRepository, IUnitOfWork uof)
    {
        _reservaSalaRepository = reservaSalaRepository;
        _uof = uof;
    }

    public async Task<DeletarReservaSalaResponse> Handle(DeletarReservaSalaRequest request, CancellationToken cancellationToken)
    {
        var reserva = await _reservaSalaRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return new DeletarReservaSalaResponse { Mensagem = "Reserva não encontrada" };

        _reservaSalaRepository.Deletar(reserva);
        await _uof.Commit(cancellationToken);
        return new DeletarReservaSalaResponse { Mensagem = "Reserva deletada com sucesso" };
    }
}
