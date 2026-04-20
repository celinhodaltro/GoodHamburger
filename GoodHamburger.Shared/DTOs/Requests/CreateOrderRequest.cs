namespace GoodHamburger.Shared.DTOs.Requests;

public record CreateOrderRequest(List<Guid> ProductIds);
