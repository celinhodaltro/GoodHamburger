using GoodHamburger.Shared.DTOs.Requests;
using MediatR;

namespace GoodHamburger.Application.Commands.CreateOrderCommand;

public record CreateOrderCommand(CreateOrderRequest request) : IRequest<Guid>;
