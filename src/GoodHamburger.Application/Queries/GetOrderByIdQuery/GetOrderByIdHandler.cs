using AutoMapper;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.DTOs;
using MediatR;

namespace GoodHamburger.Application.Queries;

public record GetOrderByIdHandler: IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order? order = await _context.Orders.FindAsync(request.Id);
        OrderDto orderDto = _mapper.Map<OrderDto>(order);

        return orderDto;
    }
}
