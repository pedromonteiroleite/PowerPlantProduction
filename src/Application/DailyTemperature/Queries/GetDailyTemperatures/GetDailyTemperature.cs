using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Services;
using MediatR;

namespace Application.DailyTemperature.Queries.GetRecordedDailyTemperatures;

public record GetDailyTemperatureQuery: IRequest<IEnumerable<DailyTemperatureDto>>;

public class GetDailyTemperatureHandler : IRequestHandler<GetDailyTemperatureQuery, IEnumerable<DailyTemperatureDto>>
{

    private readonly IMapper _mapper;
    private readonly IStorageAccountService _storageAccount;

    public GetDailyTemperatureHandler(IMapper mapper, IStorageAccountService storageAccount)
    {
        _mapper = mapper;
        _storageAccount = storageAccount;
    }

    public async Task<IEnumerable<DailyTemperatureDto>> Handle(GetDailyTemperatureQuery request, CancellationToken cancellationToken)
    {
        //await TestBlobAccess();

        var temperatureService = new DailyTemperatureService();
        var data = temperatureService.GenerateTemperature();
        return _mapper.Map<List<Domain.Entities.DailyTemperature>, List<DailyTemperatureDto>>(data);
    }

    private async Task TestBlobAccess()
    {
        
        await _storageAccount.DownloadBlob("", "");
    }

}
