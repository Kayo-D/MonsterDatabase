using static System.Console;
public class UI
{
    public void RunUI()
    {
        DB db = new DB();
        List<Monster> monsterlist = new List<Monster>();
        List<Monster> monster = db.GetMonsterFromDB(1);
        List<Monster> monster2 = db.GetMonsterFromDB(2);
        List<Monster> randomMonster = db.GetRandomMonster(20);
        //List<Monster> monstersearch = db.Search(ReadLine());
        monsterlist.Add(monster[0]);
        monsterlist.Add(monster2[0]);
        monsterlist.Add(randomMonster[0]);
        //monsterlist.Add(monstersearch[0]);
        foreach (var item in monsterlist)
        {
            WriteLine();
            item.CurrentHitPoints = item.HitPointsMax;
            WriteLine("Name : " + item.Name);
            WriteLine();
            WriteLine("CR : " + item.ChallengeRating);
            WriteLine("AC : " + item.ArmorClass);
            WriteLine("Max Hitpoints : " + item.HitPointsMax);
            WriteLine("Resistances : " + item.Resistances);
            WriteLine("Vulnerabilities : " + item.Vulnerabilities);
            WriteLine("Immunities : " + item.Immunities);
            Write("Attacks : ");
            foreach (var attack in item.Attacks)
            {
                Write(attack + ", ");
            }
            WriteLine();
            Write("Abilities : ");
            foreach (var ability in item.Abilities)
            {
                Write(ability + ", ");
            }
            WriteLine();
        }
        WriteLine();
        WriteLine("Monsters in database : " + monsterlist.Count);
    }
    public void AddMonsterUI()
    {
        DB db = new DB();
        Monster monster = new Monster();
        monster.Name = "Adult Bronze Dragon";
        monster.ChallengeRating = 15;
        monster.ArmorClass = 19;
        monster.HitPointsMax = 212;
        monster.Immunities = "Lightning";
        monster.Speed = 40;
        monster.Size = "Huge";
        monster.HitModifier = 12;
        monster.DamageModifier = 7;
        db.AddMonsterToDB(monster);
    }
    public void RemoveMonsterUI()
    {
        DB db = new DB();
        db.RemoveMonsterFromDB(ReadLine());
    }
    public void GetAverageCRUI()
    {
        DB db = new DB();
        List<Monster> monsterlist = db.GetAllMonstersBelowAverageChallengeRatingFromDB();
        foreach (var item in monsterlist)
        {
            WriteLine();
            item.CurrentHitPoints = item.HitPointsMax;
            WriteLine("Name : " + item.Name);
            WriteLine();
            WriteLine("CR : " + item.ChallengeRating);
            WriteLine("AC : " + item.ArmorClass);
            WriteLine("Max Hitpoints : " + item.HitPointsMax);
            WriteLine("Resistances : " + item.Resistances);
            WriteLine("Vulnerabilities : " + item.Vulnerabilities);
            WriteLine("Immunities : " + item.Immunities);
            Write("Attacks : ");
            foreach (var attack in item.Attacks)
            {
                Write(attack + ", ");
            }
            WriteLine();
            Write("Abilities : ");
            foreach (var ability in item.Abilities)
            {
                Write(ability + ", ");
            }
            WriteLine();
        }
        WriteLine();
        WriteLine("Monsters below average CR in database : " + monsterlist.Count);
    }
    public void ChangeMonsterNameUI()
    {
        DB db = new DB();
        WriteLine("Write old name then new name");
        db.ChangeMonsterNameInDB(ReadLine(), ReadLine());
    }
}