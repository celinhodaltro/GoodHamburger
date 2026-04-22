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

    public async Task<OrderDto?> GetOrderByIdAsync(Guid orderId)
    {
        return await _http.GetFromJsonAsync<OrderDto>($"Order/{orderId}");
    }

    public async Task<Guid> CreateOrderAsync(CreateOrderRequest request)
    {
        var response = await _http.PostAsJsonAsync("Order", request);

        await EnsureSuccess(response);

        return await response.Content.ReadFromJsonAsync<Guid>();
    }

    public async Task<bool> DeleteOrderAsync(Guid orderId)
    {
        var response = await _http.DeleteAsync($"Order/{orderId}");

        await EnsureSuccess(response);

        return await response.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<bool> UpdateOrderAsync(UpdateOrderRequest request)
    {
        var response = await _http.PutAsJsonAsync("Order", request);

        await EnsureSuccess(response);

        return await response.Content.ReadFromJsonAsync<bool>();
    }

    private static async Task EnsureSuccess(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var error = await response.Content
            .ReadFromJsonAsync<ApiResponse<object>>();

        throw new Exception(
            error?.Detail ?? "Erro ao processar requisição.");
    }
}