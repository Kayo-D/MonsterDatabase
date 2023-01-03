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
    public List<Monster> Search(string monsterName)
    {
        List<Monster> monsterlist = Connection().Query<Monster>($"SELECT * FROM `monsters` ").ToList();
        List<Monster> monstersFound = new();
        foreach (var item in monsterlist)
        {
            if (item.Name == monsterName)
            {
                monstersFound.Add(item);
                List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {monstersFound[0].ID};").ToList();
                List<string> abilities = Connection().Query<string>($"SELECT Name AS Abilities FROM abilities INNER JOIN monsterabilities ON abilities.ID = monsterabilities.Ability_ID WHERE monsterabilities.Monster_ID = {monstersFound[0].ID};").ToList();
                foreach (var attack in attacks)
                {
                    monstersFound[0].Attacks.Add(attack);
                }
                foreach (var ability in abilities)
                {
                    monstersFound[0].Abilities.Add(ability);
                }
            }
        }
        return monstersFound;
    }
    //This function and search does the same thing
    public List<Monster> GetMonsterFromDB(string monsterName)
    {
        List<Monster> monster = Connection().Query<Monster>($"SELECT * FROM `monsters` WHERE monsters.Name = {monsterName};").ToList();
        List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {monster[0].ID};").ToList();
        List<string> abilities = Connection().Query<string>($"SELECT Name AS Abilities FROM abilities INNER JOIN monsterabilities ON abilities.ID = monsterabilities.Ability_ID WHERE monsterabilities.Monster_ID = {monster[0].ID};").ToList();
        foreach (var item in attacks)
        {
            monster[0].Attacks.Add(item);
        }
        foreach (var item in abilities)
        {
            monster[0].Abilities.Add(item);
        }
        return monster;
    }
    public List<Monster> GetAllMonstersFromDB()
    {
        List<Monster> list = Connection().Query<Monster>($"Select * FROM monsters").ToList();
        foreach (var item in list)
        {
            List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {item.ID};").ToList();
            List<string> abilities = Connection().Query<string>($"SELECT Name AS Abilities FROM abilities INNER JOIN monsterabilities ON abilities.ID = monsterabilities.Ability_ID WHERE monsterabilities.Monster_ID = {item.ID};").ToList();
            foreach (var attack in attacks)
            {
                item.Attacks.Add(attack);
            }
            foreach (var ability in abilities)
            {
                item.Abilities.Add(ability);
            }
        }
        return list;
    }
    public void GetWeaponFromDB()
    {

    }
    public void AddMonsterToDB(Monster monster)
    {
        Connection().Query($"INSERT INTO `monsters` (`ID`, `Name`, `ChallengeRating`, `ArmorClass`, `HitPointsMax`, `Resistances`, `Vulnerabilities`, `Immunities`, `Speed`, `Size`, `HitModifier`, `DamageModifier`) VALUES (NULL, '{monster.Name}', '{monster.ChallengeRating}', '{monster.ArmorClass}', '{monster.HitPointsMax}', '{monster.Resistances}', '{monster.Vulnerabilities}', '{monster.Immunities}', '{monster.Speed}', '{monster.Size}', '{monster.HitModifier}', '{monster.DamageModifier}');");
    }
    public void RemoveMonsterFromDB(string monsterName)
    {
        Connection().Query($"DELETE FROM monsters WHERE Name = '{monsterName}';");
    }
    public void AddWeaponToDB()
    {

    }
    public void RemoveWeaponFromDB()
    {

    }
    public List<Monster> GetRandomMonster(int maxChallengeRating)
    {
        Random rng = new Random();
        List<Monster> list = Connection().Query<Monster>($"SELECT * FROM monsters WHERE monsters.ChallengeRating < {maxChallengeRating};").ToList();
        List<Monster> returnMonster = new List<Monster>();
        returnMonster.Add(list[rng.Next(list.Count)]);
        foreach (var item in returnMonster)
        {
            List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {item.ID};").ToList();
            List<string> abilities = Connection().Query<string>($"SELECT Name AS Abilities FROM abilities INNER JOIN monsterabilities ON abilities.ID = monsterabilities.Ability_ID WHERE monsterabilities.Monster_ID = {item.ID};").ToList();
            foreach (var attack in attacks)
            {
                item.Attacks.Add(attack);
            }
            foreach (var ability in abilities)
            {
                item.Abilities.Add(ability);
            }
        }
        return returnMonster;
    }
    public void AddAbilityToDB()
    {

    }
    public List<Monster> GetAllMonstersBelowAverageChallengeRatingFromDB()
    {
        List<Monster> returnMonster = Connection().Query<Monster>($"SELECT * FROM monsters WHERE monsters.ChallengeRating <= (SELECT AVG(monsters.ChallengeRating) FROM monsters);").ToList();
        foreach (var item in returnMonster)
        {
            List<string> attacks = Connection().Query<string>($"SELECT Name AS Attacks FROM attacks INNER JOIN monsterattacks ON monsterattacks.Attack_ID = attacks.ID WHERE monsterattacks.Monster_ID = {item.ID};").ToList();
            List<string> abilities = Connection().Query<string>($"SELECT Name AS Abilities FROM abilities INNER JOIN monsterabilities ON abilities.ID = monsterabilities.Ability_ID WHERE monsterabilities.Monster_ID = {item.ID};").ToList();
            foreach (var attack in attacks)
            {
                item.Attacks.Add(attack);
            }
            foreach (var ability in abilities)
            {
                item.Abilities.Add(ability);
            }
        }
        return returnMonster;
    }
    public void ChangeMonsterNameInDB(string oldName, string newName)
    {
        Connection().Query($"UPDATE `monsters` SET `Name` = '{newName}' WHERE `monsters`.`Name` = '{oldName}';");
    }
}