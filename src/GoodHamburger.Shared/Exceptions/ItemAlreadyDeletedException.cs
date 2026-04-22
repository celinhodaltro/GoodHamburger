namespace GoodHamburger.Shared.Exceptions;

public class ItemAlreadyDeletedException : Exception
{

    public ItemAlreadyDeletedException(string? message) : base(message)
    {
    }
}
