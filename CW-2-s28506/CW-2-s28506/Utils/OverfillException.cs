namespace CW_2_s28506.Utils;

public class OverfillException : Exception
{
    public OverfillException() {}

    public OverfillException(string message)
        : base(message) {}
    public OverfillException(string message, Exception innerException)
        : base(message, innerException) {}
}