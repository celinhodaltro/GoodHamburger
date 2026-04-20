namespace GoodHamburger.Shared.DTOs.Requests;

public record UpdateOrderRequest(Guid OrderId, List<Guid> ProductIds);
