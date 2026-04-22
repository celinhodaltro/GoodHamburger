using FluentValidation;

namespace GoodHamburger.Application.Commands;

internal class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.request).NotNull()
                               .WithMessage("A requisição não pode ser nula");

        RuleFor(x => x.request.OrderId).NotNull()
                       .WithMessage("É ID do pedido não pode ser nulo");

        RuleFor(x => x.request.ProductIds).NotEmpty()
                                          .WithMessage("A lista de produtos não pode ser vazia");
    }
}
