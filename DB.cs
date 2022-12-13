using Dapper;
using MySqlConnector;

public class DB
{
    public MySqlConnection Connection()
    {
        MySqlConnection connection = new();
        connection = new MySqlConnection("Server=localhost;Database=monsterdatabase;Uid=root;");
        return connection;
    }
    public void Search()
    {

    }
    public List<Monster> GetMonsterFromDB(int monsterID)
    {
        List<Monster> monster = Connection().Query<Monster>($"SELECT * FROM `monsters` WHERE monsters.ID = {monsterID};").ToList();
        List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {monsterID};").ToList();
        List<string> abilities = Connection().Query<string>($"").ToList();
        foreach(var item in attacks)
        {
            monster[0].Attacks.Add(item);
        }
        foreach(var item in abilities)
        {
            monster[0].Abilities.Add(item);
        }
        return monster;
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
    public void GetRandomMonster()
    {

    }
}