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
    public void CombatEncounter()
    {
        //Fight one or more monsters at once
    }
    public void AddMonsterToEncounter()
    {

    }
    public void RandomMonster()
    {

    }
    public void RandomMonsterAttack()
    {

    }
    public void ShowMonsterInfo()
    {
        //Everything combat relevant
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
    public void AddWeaponToMonster()
    {

    }
    public void RemoveWeaponFromMonster()
    {

    }
}