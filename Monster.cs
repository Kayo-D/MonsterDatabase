public class Monster
{
    private string? Name;
    private float ChallengeRating;
    private int ArmorClass;
    private int HitPointsMax;
    private int CurrentHitPoints;
    private string[]? Resistances;
    private string[]? Vulnerabilities;
    private string[]? Immunities;
    private string[]? Attacks;
    private string[]? Abilities;
    public List<string>? Weapons;
    public Monster(string name, float challengeRating, int armorClass, int hitPointsMax,
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
    }
}