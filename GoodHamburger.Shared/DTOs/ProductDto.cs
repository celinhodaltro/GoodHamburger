using GoodHamburger.Shared.Enum;

namespace GoodHamburger.Shared.DTOs;

public record ProductDto(
    Guid Id,
    string Name,
    ProductCategory Category,
    decimal Price
);
