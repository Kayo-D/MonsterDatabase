using static System.Console;

public class CreateMonsterUI
{
    private string? name;
    private int challengeRating;
    private int armorClass;
    private int hitPointsMax;
    private string[] damageTypes = new string[11]
    { "Acid", "Cold", "Fire","Force", "Lightning", "Necrotic","Physical", "Poison", "Psychic", "Radiant", "Thunder" };
    private List<string> resistanceTypes = new List<string>();
    private string[]? resistances;
    public void Run()
    {
        SetName();
        SetChallengeRating();
        SetArmorClass();
        SetHitPointsMax();
        SetResistances();
        DrawAddAnotherUI("resistance");
        while (true)
        {
            if (YesNoChoice())
            {
                SetResistances();
            }
            else
            {
                break;
            }
        }
    }
    public void SetName()
    {
        while (true)
        {
            DrawSetNameUI();
            name = ReadLine();
            if (name != "")
            {
                break;
            }
        }
    }
    public void DrawSetNameUI()
    {
        Clear();
        WriteLine("Write the monsters name :");
    }
    public void SetChallengeRating()
    {
        bool succesfulparse = false;
        while (succesfulparse == false)
        {
            DrawSetChallengeRatingUI();
            succesfulparse = int.TryParse(ReadLine(), out challengeRating);
        }
    }
    public void DrawSetChallengeRatingUI()
    {
        Clear();
        WriteLine($"Write {name}s challengerating : ");
    }
    public void SetArmorClass()
    {
        bool succesfulparse = false;
        while (succesfulparse == false)
        {
            DrawSetArmorClassUI();
            succesfulparse = int.TryParse(ReadLine(), out armorClass);
        }
    }
    public void DrawSetArmorClassUI()
    {
        Clear();
        WriteLine($"Write {name}s armor class : ");
    }
    public void SetHitPointsMax()
    {
        bool succesfulparse = false;
        while (succesfulparse == false)
        {
            DrawSetHitPointsMaxUI();
            succesfulparse = int.TryParse(ReadLine(), out hitPointsMax);
        }
    }
    public void DrawSetHitPointsMaxUI()
    {
        Clear();
        WriteLine($"Write {name}s total hit points");
    }
    public void SetResistances()
    {
        int input;
        bool succesfulparse = false;
        while (succesfulparse == false)
        {
            DrawSetResistancesUI();
            DrawDamageTypes();
            succesfulparse = int.TryParse(ReadLine(), out input);
            if (input < 12)
            {
                resistanceTypes.Add(damageTypes[input+1]);
            }
            else
            {
                ErrorCodeWrongDamageType();
            }
        }
    }
    public void DrawSetResistancesUI()
    {
        Clear();
        WriteLine($"Write in a number corresponding to the resistance you wish to add. Write (C) in order to continue.");
    }
    public void DrawDamageTypes()
    {
        WriteLine("1  : Acid");
        WriteLine("2  : Cold");
        WriteLine("3  : Fire");
        WriteLine("4  : Force");
        WriteLine("5  : Lightning");
        WriteLine("6  : Necrotic");
        WriteLine("7  : Physical");
        WriteLine("8  : Poison");
        WriteLine("9  : Psychic");
        WriteLine("10 : Radiant");
        WriteLine("11 : Thunder");
    }
    public void DrawAddAnotherUI(string type)
    {
        Clear();
        WriteLine($"Would you like to add another {type}? (Y/N)");
    }
    public bool YesNoChoice()
    {
        bool returnbool = false;
        bool breakloop = false;
        while(breakloop == false)
        {
            string? input = ReadLine();
            if (input?.ToLower() == "y")
            {
                returnbool = true;
                breakloop = true;
            }
            else if (input?.ToLower() == "n")
            {
                returnbool = false;
                breakloop = true;
            }
            else
            {
                breakloop = false;
            }
        }
        return returnbool;
    }
    public void ErrorCodeWrongDamageType()
    {
        WriteLine("Please put in a number between 1 and 11");
    }
}