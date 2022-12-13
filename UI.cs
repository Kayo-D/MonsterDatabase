using static System.Console;
public class UI
{
    public void Run()
    {
        DB db = new DB();
        List<Monster> monsterlist = new List<Monster>();
        List<Monster> monster = db.GetMonsterFromDB(1);
        List<Monster> monster2 = db.GetMonsterFromDB(2);
        List<Monster> randomMonster = db.GetRandomMonster(20);
        monsterlist.Add(monster[0]);
        monsterlist.Add(monster2[0]);
        monsterlist.Add(randomMonster[0]);
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
}