using FluentValidation.Results;
using MediatR;

namespace Stoqui.Kernel.Domain.Messages;


public abstract class Command : IRequest<bool>
{
    public string MessageType { get; private set; }
    public DateTime Timestamp { get; private set; }
    public ValidationResult? ValidationResult { get; protected set; }

    public Command()
    {
        MessageType = GetType().Name;
        Timestamp = DateTime.Now;
    }

    public abstract bool IsValid();

}

