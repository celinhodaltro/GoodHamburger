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

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            throw new Exception(error?.Detail ?? "Erro ao processar requisição.");
        }

        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var response = await _http.DeleteAsync($"Order/{orderId}");

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateOrderAsync(Guid id, UpdateOrderRequest request)
    {
        var response = await _http.PutAsJsonAsync($"Order/{id}", request);

        response.EnsureSuccessStatusCode();
    }
}