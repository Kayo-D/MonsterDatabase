public class Monster
{
    public int ID;
    public string? Name;
    public float ChallengeRating;
    public int ArmorClass;
    public int HitPointsMax;
    public int CurrentHitPoints;
    public string? Resistances;
    public string? Vulnerabilities;
    public string? Immunities;
    public int Speed;
    public string? Size;
    public int HitModifier;
    public int DamageModifier;
    public List<string> Attacks = new List<string>();
    public List<string> Abilities = new List<string>();
    public List<string> Weapons = new List<string>();
    /* public Monster(string name, float challengeRating, int armorClass, int hitPointsMax,
    string[]? resistances, string[]? vulnerabilities, string[]? immunities, string[]? attacks, string[]? abilities)
    {
        this.Name = name;
        this.ChallengeRating = challengeRating;
        this.ArmorClass = armorClass;
        this.HitPointsMax = hitPointsMax;
        this.CurrentHitPoints = this.HitPointsMax;
        this.Resistances = resistances;
        this.Vulnerabilities = vulnerabilities;
        this.Immunities = immunities;
        this.Attacks = attacks;
        this.Abilities = abilities;
    } */
    public void AddWeapon(string weaponName)
    {
        Weapons.Add(weaponName);
    }
    public void RemoveWeapon(string weaponName)
    {
        Weapons.Remove(weaponName);
    }
}