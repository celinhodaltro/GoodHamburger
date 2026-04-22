using FluentValidation;

namespace GoodHamburger.Application.Queries;
public class GetProductsByOrderIdValidator : AbstractValidator<GetProductsByOrderIdQuery>
{

    public GetProductsByOrderIdValidator()
    {
        RuleFor(x => x.OrderId).NotNull()
                               .WithMessage("É preciso selecionar uma ordem para exclusão");

    }
}
