namespace HallApp.BusinessLogic.Exceptions;

public class HallAppException : Exception
{
    public HallAppException()
    {
    }

    public HallAppException(string? message) 
        : base(message)
    {
    }

    public HallAppException(string? message, Exception? innerException) 
        : base(message, innerException)
    {
    }
}
