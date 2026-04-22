using GoodHamburger.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace GoodHamburger.Application.Queries;

public class GetProductsByOrderIdHandler : IRequestHandler<GetProductsByOrderIdQuery, List<Guid?>>
{
    private readonly ApplicationDbContext _context;

    public GetProductsByOrderIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Guid?>> Handle(GetProductsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        var products = await _context.OrderItems.AsNoTracking()
                                                .Where(x =>
                                                    !x.IsDeleted &&
                                                    x.OrderId == request.OrderId)
                                                .Select(x => x.ProductId)
                                                .ToListAsync();
        return products;

    }
}