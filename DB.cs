using Dapper;
using MySqlConnector;

public class DB
{
    public MySqlConnection Connection()
    {
        MySqlConnection connection = new();
        connection = new MySqlConnection("Server=localhost;Database=videoteket;Uid=root;");
        return connection;
    }
    public void Search()
    {

    }
}