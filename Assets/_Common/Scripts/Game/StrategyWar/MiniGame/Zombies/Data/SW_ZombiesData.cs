using UnityEngine;

[System.Serializable]
public class SW_ZombiesData
{
    [SerializeField] private SW_ZombieData[] _zombies;

    public SW_ZombieData GetZombieById(string id)
    {
        foreach (var zombie in _zombies)
        {
            if (zombie.Id == id)
            {
                return zombie;
            }
        }

        return null;
    }
}
