using AutoMapper;
using Domain.Entities;

namespace Application.DailyTemperature.Queries.GetRecordedDailyTemperature
{
    public class RecordedDailyTemperatuteDto
    {
        public double HighTemp { get; set; }
        public double LowTemp { get; set; }

        private class Mapping: Profile
        {
            public Mapping()
            {
                CreateMap<RecordedDailyTemperature, RecordedDailyTemperatuteDto>();
            }
        }

    }
}
