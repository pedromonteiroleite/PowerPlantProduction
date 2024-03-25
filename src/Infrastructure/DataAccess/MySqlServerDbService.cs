using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Infrastructure.DataAccess;

public class MySqlServerDbService : IApplicationDbService
{
    private readonly IConfiguration _configuration;

    public MySqlServerDbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(_configuration.GetConnectionString("MySQLConnection"));
    }

    public List<RecordedDailyTemperature> GetRecordedDailyTemperature()
    {
        var conn = GetConnection();
        var result = new List<RecordedDailyTemperature>();
        string statement = "SELECT HighTemp, LowTemp FROM RecordedDailyTemperature";
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(statement, conn);
        using (MySqlDataReader reader = cmd.ExecuteReader())
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
