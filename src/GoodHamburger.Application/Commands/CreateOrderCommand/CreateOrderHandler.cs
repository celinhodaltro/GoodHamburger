
using FluentValidation;
using GoodHamburger.Domain.Entities;
using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.DTOs.Requests;
using GoodHamburger.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburger.Application.Commands.CreateOrderCommand;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    public CreateOrderHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

        var products = await _context.Products.AsNoTracking()
                                              .Where(p => request.request.ProductIds.Contains(p.Id))
                                              .ToListAsync();

        if (!products.Any())
            throw new NotFoundException("Nenhum produto encontrado");

        var order = new Order();

        foreach (var product in products)
        {
            order.AddItem(new OrderItem(product));
        }

        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
