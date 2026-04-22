using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Commands;

public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateOrderHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.Include(x => x.OrderItems)
                                         .FirstOrDefaultAsync(x => !x.IsDeleted &&
                                                              x.Id == request.request.OrderId,
                                                              cancellationToken);

        var products = await _context.Products.Where(x => request.request.ProductIds.Contains(x.Id))
                                              .ToListAsync(cancellationToken);

        if (order is null)
            throw new NotFoundException("Pedido não foi encontrado.");

        if (!products.Any())
            throw new NotFoundException("Nenhum produto encontrado.");

        _context.OrderItems.RemoveRange(_context.OrderItems.Where(x => x.OrderId == order.Id));
        await _context.SaveChangesAsync(cancellationToken);

        order.ClearItems();

        foreach (var product in products)
            _context.OrderItems.Add(order.AddItem(new OrderItem(product)));

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}