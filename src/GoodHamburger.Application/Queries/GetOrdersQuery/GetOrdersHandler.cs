using AutoMapper;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.DTOs;
using GoodHamburger.Shared.DTOs.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Queries;

public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, GetOrdersResponse>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrdersHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetOrdersResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        List<Order> orders = await _context.Orders.AsNoTracking()
                                                  .Where(order => !order.IsDeleted)
                                                  .ToListAsync();

        List<OrderDto> ordersDtos = _mapper.Map<List<OrderDto>>(orders);
        GetOrdersResponse response = new GetOrdersResponse(ordersDtos);

        return response;
    }
}
