using UnityEngine;

public class SW_BulletsDataComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_BulletData[] _bulletsData;

    public SW_BulletData GetData(string name)
    {
        foreach (var data in _bulletsData)
        {
            if (data.Name == name)
            {
                return data;
            }
        }

        return null;
    }
}
