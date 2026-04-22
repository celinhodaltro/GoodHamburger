using GoodHamburger.Shared.DTOs.Responses;
using MediatR;

namespace GoodHamburger.Application.Queries;

public record GetProductsByOrderIdQuery(Guid OrderId) : IRequest<List<Guid?>>;
