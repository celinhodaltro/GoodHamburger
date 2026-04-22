using GoodHamburger.Domain.Exceptions;
using GoodHamburger.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburger.API.Middlewares;

public class GlobalExceptionMiddleware : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, exception.Message);

        var response = exception switch
        {
            BusinessException => new ProblemDetails
            {
                Title = "Regra de negócio violada",
                Status = 400,
                Detail = exception.Message
            },
            NotFoundException => new ProblemDetails
            {
                Title = "Recurso não encontrado",
                Status = 400,
                Detail = exception.Message
            },
            FluentValidation.ValidationException => new ProblemDetails
            {
                Title = "Dados inválidos",
                Status = 400,
                Detail = exception.Message
            },
            ItemAlreadyDeletedException => new ProblemDetails
            {
                Title = "Recurso ja foi deletado.",
                Status = 400,
                Detail = exception.Message
            },
            _ => new ProblemDetails
            {
                Title = "Erro interno do servidor",
                Status = 500,
                Detail = "Ocorreu um erro inesperado."
            }
        };

        context.Response.StatusCode = response.Status!.Value;

        await context.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}