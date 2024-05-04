using MediatR;

namespace Application.DailyTemperature.Commands.CreateDailyTemperature;

public record CreateDailyTemperatureCommand : IRequest<int>
{
    public double HighTemp { get; init; }

    public double LowTemp { get; init; }
}

public class CreateDailyTemperatureCommandHandler : IRequestHandler<CreateDailyTemperatureCommand, int>
{
    
    public CreateDailyTemperatureCommandHandler()
    {
    }

    public async Task<int> Handle(CreateDailyTemperatureCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.DailyTemperature
        {
             HighTemp = request.HighTemp,
             LowTemp = request.LowTemp
        };

        return Int32.MinValue;
    }
}