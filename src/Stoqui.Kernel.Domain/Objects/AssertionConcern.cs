using Stoqui.Kernel.Domain.Exceptions;

namespace Stoqui.Kernel.Domain.Objects;

public static class AssertionConcern
{
    #region Assertions
        
    public static void NotNull(object value, string errorMessage)
    {
        if (value == null)
            AssertionConcernException.ThrowException(errorMessage);
    }


    public static void NotEmpty(string value, string errorMessage)
    {
        if(value == null || value == string.Empty || value.Trim() == "" )
            AssertionConcernException.ThrowException(errorMessage);
    }

    public static void NotEmpty(Guid value, string errorMessage)
    {
        if (value == Guid.Empty)
            AssertionConcernException.ThrowException(errorMessage);
    }


    public static void GreaterThan(int greater, int than, string errorMessage)
    {
        if (greater <= than)
            AssertionConcernException.ThrowException(errorMessage);
    }

    #endregion

    #region Assertion State
    #endregion

    public static void NotImplementedException(string errorMessage = "Not Implemented Exception")
    {
        AssertionConcernException.ThrowException(errorMessage);
    }

}

