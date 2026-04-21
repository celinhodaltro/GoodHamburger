using GoodHamburger.Shared.Enum;

namespace GoodHamburger.Shared.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    ProductCategory Category,
    decimal Price
);
