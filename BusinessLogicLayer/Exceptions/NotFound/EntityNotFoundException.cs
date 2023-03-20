namespace BusinessLogicLayer.Exceptions.NotFound;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}