using FluentValidation;
using FluentValidation.Results;
using GoodHamburger.Domain.Exceptions;

namespace GoodHamburger.Application.Commands.CreateOrderCommand;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{

    public CreateOrderValidator()
    {
        RuleFor(x => x.request).NotNull()
                               .WithMessage("A requisição não pode ser nula");

        RuleFor(x => x.request.ProductIds).NotEmpty()
                                          .WithMessage("A lista de produtos não pode ser vazia");
    }
    
}
