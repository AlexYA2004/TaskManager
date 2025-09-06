namespace TaskManager.Core.Exceptions.TaskExceptions;

public class ChangeTaskStatusException : DomainException
{
    public ChangeTaskStatusException(string message) : base(message)
    {
    }

    public ChangeTaskStatusException(string message, Exception innerException) : base(message, innerException)
    {
    }
}