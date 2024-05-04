using MediatR;

namespace Application.HighTemperatureNotification.Commands.CreateHighTempAlert;

public class CreateHighTempAlertNotification : INotification
{
    public double HighTempExpected { get; init; }

    public string Message { get; init; } = string.Empty;
}

public class CreateHighTempAlertCommandHandler : INotificationHandler<CreateHighTempAlertNotification>
{
    public async Task Handle(CreateHighTempAlertNotification request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Notify");
    }
}