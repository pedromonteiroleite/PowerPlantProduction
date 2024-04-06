using AutoMapper;
using Domain.Services;
using MediatR;

namespace Application.DailyTemperature.Queries.GetRecordedDailyTemperatures;

public record GetDailyTemperatureQuery: IRequest<IEnumerable<DailyTemperatureDto>>;

public class GetDailyTemperatureHandler : IRequestHandler<GetDailyTemperatureQuery, IEnumerable<DailyTemperatureDto>>
{

    private readonly IMapper _mapper;

    public GetDailyTemperatureHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<DailyTemperatureDto>> Handle(GetDailyTemperatureQuery request, CancellationToken cancellationToken)
    {
        var temperatureService = new DailyTemperatureService();
        var data = temperatureService.GenerateTemperature();
        return _mapper.Map<List<Domain.Entities.DailyTemperature>, List<DailyTemperatureDto>>(data);
    }

}
