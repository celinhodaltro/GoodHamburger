using GoodHamburger.Shared.DTOs.Responses;
using MediatR;

namespace GoodHamburger.Application.Queries;

public record GetOrdersQuery : IRequest<GetOrdersResponse>;