
using FluentValidation;
using GoodHamburger.Application.Commands;

namespace GoodHamburger.Application.Queries;

public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
{

    public GetOrderByIdValidator()
    {
        RuleFor(x => x.OrderId).NotNull()
                               .WithMessage("É preciso selecionar uma ordem para exclusão.");

    }
}
