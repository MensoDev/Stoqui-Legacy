namespace Stoqui.Kernel.Domain.Exceptons;

public class AssertionConcernException : Exception
{
    public AssertionConcernException(string errorMessage) : base(errorMessage) {}

    public AssertionConcernException(string errorMessage, Exception innerException) : base(errorMessage, innerException) {}
    

    public static void ThrowException(string errorMessage)
    {
        throw new AssertionConcernException(errorMessage);
    }
}

