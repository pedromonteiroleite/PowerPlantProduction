using AutoMapper;

namespace Application.DailyTemperature.Queries.GetRecordedDailyTemperatures;
public class DailyTemperatureDto
{
    public double HighTemp { get; set; }
    public double LowTemp { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.DailyTemperature, DailyTemperatureDto>();
        }
    }

}
