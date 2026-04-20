using AutoMapper;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.DTOs;
using GoodHamburger.Shared.DTOs.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Queries;

public class GetMenuHandler : IRequestHandler<GetMenuQuery, GetMenuResponse>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public GetMenuHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetMenuResponse> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products.AsNoTracking()
                                              .Where(product => !product.IsDeleted)
                                              .ToListAsync();

        var productDtos = _mapper.Map<List<ProductDto>>(products);
        return new GetMenuResponse(productDtos);

    }
}
