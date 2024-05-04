using MediatR;

namespace Application.HighTemperatureNotification.Commands.CreateHighTempAlert;

public class CreateHighTempAlertSecondCommandHandler : INotificationHandler<CreateHighTempAlertNotification>
{
    public async Task Handle(CreateHighTempAlertNotification request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Notify");
    }
}