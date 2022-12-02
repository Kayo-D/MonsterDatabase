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
    public void /* Monster */ GetMonsterFromDB()
    {

    }
    public void GetWeaponFromDB()
    {
        
    }
    public void AddMonsterToDB()
    {
        
    }
    public void RemoveMonsterFromDB()
    {

    }
    public void AddWeaponToDB()
    {

    }
    public void RemoveWeaponFromDB()
    {

    }
}