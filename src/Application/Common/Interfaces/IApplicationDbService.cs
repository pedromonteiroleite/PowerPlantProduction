
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IApplicationDbService
{
    List<RecordedDailyTemperature> GetRecordedDailyTemperature();
}