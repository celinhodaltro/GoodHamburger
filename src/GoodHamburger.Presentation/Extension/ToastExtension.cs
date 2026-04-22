using GoodHamburger.Presentation.Services;

namespace GoodHamburger.Presentation.Extension;
public static class ToastExtension
{
    public static async Task HandleToast(
        this Task task,
        ToastService toast,
        string message,
        ToastType type = ToastType.Info)
    {
        try
        {
            await task;
            toast.Send(message, type);
        }
        catch (Exception ex)
        {
            toast.Send(message, ToastType.Error);
        }
    }

    public static async Task<T?> HandleToast<T>(
        this Task<T> task,
        ToastService toast,
        string message,
        ToastType type = ToastType.Info)
    {
        try
        {
            var result = await task;
            toast.Send(message, type);

            return result;
        }
        catch (Exception ex)
        {
            toast.Send(ex.Message, ToastType.Error);
            return default;
        }
    }

    public static async Task<T?> HandleToast<T>(
    this Task<T> task,
    ToastService toast)
    {
        try
        {
            var result = await task;
            return result;
        }
        catch (Exception ex)
        {
            toast.Send(ex.Message, ToastType.Error);
            return default;
        }
    }
}