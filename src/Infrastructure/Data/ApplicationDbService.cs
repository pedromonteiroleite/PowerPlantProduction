using Application.Common.Interfaces;
using Domain.Entities;
using System.Data.SqlClient;

namespace Infrastructure.Data;

public class ApplicationDbService : IApplicationDbService
{

    private static string DbSource = "";
    private static string DbUser = "";
    private static string DbPwd = "";
    private static string DbName = "";

    private SqlConnection GetConnection()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = DbSource,
            UserID = DbUser,
            Password = DbPwd,
            InitialCatalog = DbName
        };
        return new SqlConnection(builder.ConnectionString);
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
