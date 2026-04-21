using System.Net.Http.Json;
using GoodHamburger.Shared.DTOs;
using GoodHamburger.Shared.DTOs.Requests;
using GoodHamburger.Shared.DTOs.Responses;

namespace GoodHamburger.Presentation.Services;

public class OrderService
{
    private readonly HttpClient _http;

    public OrderService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetOrdersResponse?> GetOrdersAsync()
    {
        return await _http.GetFromJsonAsync<GetOrdersResponse>("Order");
    }

    public async Task<OrderDto?> GetOrderByIdAsync(Guid id)
    {
        return await _http.GetFromJsonAsync<OrderDto>($"Order/{id}");
    }

    public async Task<Guid> CreateOrderAsync(CreateOrderRequest request)
    {
        var response = await _http.PostAsJsonAsync("Order", request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Guid>();
    }
}