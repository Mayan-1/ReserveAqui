using MediatR;

namespace ReserveAqui.Application.UseCases.Material.Atualizar;

public sealed record AtualizarMaterialRequest(int Id, string Nome, 
                                              int Quantidade, string Tipo) : IRequest<AtualizarMaterialResponse>;


