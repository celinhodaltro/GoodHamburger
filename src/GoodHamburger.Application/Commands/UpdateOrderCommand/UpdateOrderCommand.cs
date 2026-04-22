using GoodHamburger.Shared.DTOs.Requests;
using MediatR;

namespace GoodHamburger.Application.Commands;
public record UpdateOrderCommand(UpdateOrderRequest request) : IRequest<bool>;
