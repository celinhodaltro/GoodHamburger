using GoodHamburger.Shared.DTOs;
using MediatR;

namespace GoodHamburger.Application.Queries;

public record GetOrderByIdQuery(Guid OrderId) : IRequest<OrderDto>;

