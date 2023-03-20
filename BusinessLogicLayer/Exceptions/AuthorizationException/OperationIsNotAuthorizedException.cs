namespace BusinessLogicLayer.Exceptions.AuthorizationException;

public class OperationIsNotAuthorizedException : Exception
{
    public OperationIsNotAuthorizedException(string message)
        : base(message)
    {
    }
}