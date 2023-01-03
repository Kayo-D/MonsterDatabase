using static System.Console;
public class UI
{
    static ConsoleKey menuKeys = ConsoleKey.NoName;
    DB db = new DB();
    public void MenuUI()
    {
        while (true)
        {
            Clear();
            WriteLine("Press: ");
            WriteLine("1: Search for monster in database");
            WriteLine("2: Add monster to database");
            WriteLine("3: Remove monster from database");
            WriteLine("4: Change name of a monster in the database");
            WriteLine("5: List all monsters in the database");
            WriteLine("6: Get a random monster below given CR");
            WriteLine("7: Get all monsters below the average CR of all monsters in the database");
            WriteLine("8: Quit");
            menuKeys = Console.ReadKey(true).Key;
            switch (menuKeys)
            {
                case ConsoleKey.D1:
                    Clear();
                    WriteLine("Write name of the monster");
                    WriteMonsters(db.Search(ReadLine()));
                    WriteLine("Press ENTER to go back to menu");
                    ReadLine();
                    break;
                case ConsoleKey.D2:
                    AddMonsterUI();
                    break;
                case ConsoleKey.D3:
                    RemoveMonsterUI();
                    break;
                case ConsoleKey.D4:
                    ChangeMonsterNameUI();
                    break;
                case ConsoleKey.D5:
                    ListAllMonstersUI();
                    break;
                case ConsoleKey.D6:
                    GetRanddomMonsterBelowCRUI();
                    break;
                case ConsoleKey.D7:
                    GetAllAverageCRUI();
                    break;
                case ConsoleKey.D8:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
    public void GetRanddomMonsterBelowCRUI()
    {
        Clear();
        WriteLine("Write max CR");
        int input;
        int.TryParse(ReadLine(), out input);
        WriteMonsters(db.GetRandomMonster(input));
        WriteLine("Press ENTER to go back");
        ReadLine();
    }
    public void ListAllMonstersUI()
    {
        Clear();
        List<Monster> list = db.GetAllMonstersFromDB();
        WriteMonsters(list);
        WriteLine("Press ENTER to go back");
        ReadLine();
    }
    public void WriteMonsters(List<Monster> monsterlist)
    {
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
    }
    public void AddMonsterUI()
    {
        //Need to add resist/vuln/immune
        DB db = new DB();
        Monster monster = new Monster();
        Clear();
        WriteLine("Set monster name");
        monster.Name = ReadLine();
        Clear();
        WriteLine("Set monster challenge rating");
        int.TryParse(ReadLine(), out monster.ChallengeRating);
        Clear();
        WriteLine("Set monster armor class");
        int.TryParse(ReadLine(), out monster.ArmorClass);
        Clear();
        WriteLine("Set monster max hitpoints");
        int.TryParse(ReadLine(), out monster.HitPointsMax);
        Clear();
        WriteLine("Set monster speed");
        int.TryParse(ReadLine(), out monster.Speed);
        Clear();
        WriteLine("Set monster size");
        monster.Size = ReadLine();
        Clear();
        WriteLine("Set monster hit modifier");
        int.TryParse(ReadLine(), out monster.HitModifier);
        Clear();
        WriteLine("Set monster damage modifier");
        int.TryParse(ReadLine(), out monster.DamageModifier);
        db.AddMonsterToDB(monster);
    }
    public void RemoveMonsterUI()
    {
        DB db = new DB();
        Clear();
        WriteLine("Write name of the monster you wish to remove");
        db.RemoveMonsterFromDB(ReadLine());
    }
    public void GetAllAverageCRUI()
    {
        Clear();
        DB db = new DB();
        List<Monster> monsterlist = db.GetAllMonstersBelowAverageChallengeRatingFromDB();
        WriteMonsters(monsterlist);
        WriteLine();
        WriteLine("Monsters below average CR in database : " + monsterlist.Count);
        WriteLine();
        WriteLine("Press ENTER to go back");
        ReadLine();
    }
    public void ChangeMonsterNameUI()
    {
        DB db = new DB();
        Clear();
        WriteLine("Write the monsters old name then the new name");
        db.ChangeMonsterNameInDB(ReadLine(), ReadLine());
    }
    /* public void RunUI()
    {
        DB db = new DB();
        List<Monster> monsterlist = new List<Monster>();
        List<Monster> monster = db.GetMonsterFromDB("Adult Red Dragon");
        List<Monster> monster2 = db.GetMonsterFromDB("Adult Black Dragon");
        //List<Monster> randomMonster = db.GetRandomMonster(20);
        //List<Monster> monstersearch = db.Search(ReadLine());
        monsterlist.Add(monster[0]);
        monsterlist.Add(monster2[0]);
        //monsterlist.Add(randomMonster[0]);
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
    } */
}