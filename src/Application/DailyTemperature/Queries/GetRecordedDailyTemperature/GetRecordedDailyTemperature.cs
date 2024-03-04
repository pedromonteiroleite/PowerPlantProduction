using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.DailyTemperature.Queries.GetRecordedDailyTemperature;

public record GetRecordedDailyTemperatureQuery: IRequest<IEnumerable<RecordedDailyTemperatuteDto>>;

public class GetRecordedDailyTemperatureHandler : IRequestHandler<GetRecordedDailyTemperatureQuery, IEnumerable<RecordedDailyTemperatuteDto>>
{

    private readonly IApplicationDbService _dbService;
    private readonly IMapper _mapper;

    public GetRecordedDailyTemperatureHandler(IApplicationDbService dbService, IMapper mapper)
    {
        _dbService = dbService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RecordedDailyTemperatuteDto>> Handle(GetRecordedDailyTemperatureQuery request, CancellationToken cancellationToken)
    {
        var data = _dbService.GetRecordedDailyTemperature();
        return _mapper.Map<List<RecordedDailyTemperature>, List<RecordedDailyTemperatuteDto>>(data);
    }

}
