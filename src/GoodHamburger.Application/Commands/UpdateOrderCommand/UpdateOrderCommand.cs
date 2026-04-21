using GoodHamburger.Shared.DTOs.Requests;
using MediatR;

namespace GoodHamburger.Application.Commands.UpdateOrderCommand;
public record UpdateOrderCommand(UpdateOrderRequest request) : IRequest<Guid>;
