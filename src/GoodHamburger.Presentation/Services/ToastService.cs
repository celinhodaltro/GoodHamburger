namespace GoodHamburger.Presentation.Services;

public class ToastService
{
    public event Action<string, ToastType>? OnShow;

    public void Send(string message, ToastType type) => OnShow?.Invoke(message, type);
}

public enum ToastType
{
    Success,
    Error,
    Warning,
    Info
}