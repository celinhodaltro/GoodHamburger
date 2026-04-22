using FluentValidation;

namespace GoodHamburger.Application.Commands;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{

    public DeleteOrderValidator()
    {
        RuleFor(x => x.OrderId).NotNull()
                               .WithMessage("É preciso selecionar uma ordem para exclusão");

    }

}
