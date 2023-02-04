using UnityEngine;

public class SW_WeaponsDataComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_WeaponData[] _weaponsData;

    public SW_WeaponData GetData(string name)
    {
        foreach (var weapon in _weaponsData)
        {
            if (weapon.Name == name)
            {
                return weapon;
            }
        }

        return null;
    }
}
