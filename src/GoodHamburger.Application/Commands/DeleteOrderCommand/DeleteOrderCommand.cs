using MediatR;

namespace GoodHamburger.Application.Commands;

public record DeleteOrderCommand(Guid OrderId): IRequest<bool>;
