
using MediatR;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.ReservaMaterialRepository;

namespace ReserveAqui.Application.UseCases.ReservaMaterial.Deletar;

public class DeletarReservaMaterialHandler : IRequestHandler<DeletarReservaMaterialRequest, DeletarReservaMaterialResponse>
{
    private readonly IReservaMaterialRepository _reservaMaterialRepository;
    private readonly IUnitOfWork _uof;
    public DeletarReservaMaterialHandler(IReservaMaterialRepository reservaMaterialRepository, IUnitOfWork uof)
    {
        _reservaMaterialRepository = reservaMaterialRepository;
        _uof = uof;
    }

    public async Task<DeletarReservaMaterialResponse> Handle(DeletarReservaMaterialRequest request, CancellationToken cancellationToken)
    {
        var reserva = await _reservaMaterialRepository.Obter(request.Id, cancellationToken);
        if (reserva == null) return new DeletarReservaMaterialResponse { Mensagem = "Reserva não encontrada" };

        _reservaMaterialRepository.Deletar(reserva);
        await _uof.Commit(cancellationToken);
        return new DeletarReservaMaterialResponse { Mensagem = "Reserva deletad com sucesso" };
    }
}
