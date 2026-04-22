namespace GoodHamburger.Shared.DTOs.Responses;

public class ApiResponse<T>
{
    public string Title { get; set; } = "";
    public int Status { get; set; }
    public string Detail { get; set; } = "";
    public T? Data { get; set; }
}