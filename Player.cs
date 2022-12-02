public class Player
{
    public int ArmorClass;
    public int HitPointsMax;
    public int CurrentHitPoints;
    public List<string> Weapons = new List<string>();
    public void AddWeapon(string weaponName)
    {
        Weapons.Add(weaponName);
    }
    public void RemoveWeapon(string weaponName)
    {
        Weapons.Remove(weaponName);
    }
}