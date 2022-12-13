using static System.Console;

//CreateMonsterUI monsterUI = new();
//monsterUI.Run();

DB db = new DB();
List<Monster> monster = db.GetMonsterFromDB(1);
monster[0].CurrentHitPoints = monster[0].HitPointsMax;
WriteLine("Name : " + monster[0].Name);
WriteLine("CR : " + monster[0].ChallengeRating);
WriteLine("AC : " + monster[0].ArmorClass);
WriteLine("HPMax : " + monster[0].HitPointsMax);
WriteLine("HPCurrent : " + monster[0].CurrentHitPoints);
WriteLine("Resistances : " + monster[0].Resistances);
WriteLine("Vulnerabilities : " + monster[0].Vulnerabilities);
WriteLine("Immunities : " + monster[0].Immunities);
WriteLine("Attacks : " + monster[0].Attacks[0] + ", " + monster[0].Attacks[1]);
WriteLine("Abilities : " + monster[0].Abilities);
WriteLine("Monsters in list : " + monster.Count);