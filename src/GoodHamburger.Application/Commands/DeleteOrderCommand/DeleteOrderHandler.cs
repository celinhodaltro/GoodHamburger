using GoodHamburger.Infrastructure.Persistence;
using GoodHamburger.Shared.Exceptions;
using MediatR;

namespace GoodHamburger.Application.Commands;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteOrderHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _context.Orders.Find(request.OrderId);

        if (order.IsDeleted)
            throw new ItemAlreadyDeletedException("Este pedido ja foi deletado.");

        order.IsDeleted = true;
        order.DeletedDate = DateTime.Now;
        _context.SaveChanges();

        return true;
    }
}
