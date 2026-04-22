using System.Net.Http.Json;
using GoodHamburger.Shared.DTOs;
using GoodHamburger.Shared.DTOs.Responses;

namespace GoodHamburger.Presentation.Services;

public class MenuService
{
    private readonly HttpClient _http;

    public MenuService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetMenuResponse?> GetMenuAsync()
    {
        return await _http.GetFromJsonAsync<GetMenuResponse>("Product");
    }

    public async Task<List<Guid>?> GetProductsByOrderIdAsync(Guid orderId)
    {
        return await _http.GetFromJsonAsync<List<Guid>>($"Product/GetProductsByOrderId/{orderId}");
    }
}