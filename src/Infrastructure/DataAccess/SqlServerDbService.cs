using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infrastructure.DataAccess;

public class ApplicationDbService : IApplicationDbService
{
    private readonly IConfiguration _configuration;

    public ApplicationDbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
    }

    public List<RecordedDailyTemperature> GetRecordedDailyTemperature()
    {
        var conn = GetConnection();
        var result = new List<RecordedDailyTemperature>();
        string statement = "SELECT HighTemp, LowTemp FROM RecordedDailyTemperature";
        conn.Open();
        SqlCommand cmd = new SqlCommand(statement, conn);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                var temperature = new RecordedDailyTemperature
                {
                    HighTemp = reader.GetDouble(0),
                    LowTemp = reader.GetDouble(1)
                };
                result.Add(temperature);
            }
        }
        conn.Close();
        return result;
    }

}
