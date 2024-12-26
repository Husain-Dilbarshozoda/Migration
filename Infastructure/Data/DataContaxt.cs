using Npgsql;

namespace Infastructure.Data;

public interface IDataContaxt
{
    NpgsqlConnection Connection();
}

public class DataContaxt :IDataContaxt
{
    private readonly string _connectionString =
        "Host=localhost;Port=5432;Database=dapper_db;User Id=postgres;Password=501040477.tj";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}