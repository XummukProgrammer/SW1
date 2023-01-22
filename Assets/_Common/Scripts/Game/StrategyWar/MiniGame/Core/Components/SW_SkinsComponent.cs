using UnityEngine;

public class SW_SkinsComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_CellSkin[] _cellSkins;
    [SerializeField] private SW_ZombieSkin[] _zombieSkins;

    public SW_CellSkin GetCellSkin(string id)
    {
        foreach (var skin in _cellSkins)
        {
            if (skin.Id == id)
            {
                return skin;
            }
        }

        return null;
    }

    public SW_ZombieSkin GetZombieSkin(string id)
    {
        foreach (var skin in _zombieSkins)
        {
            if (skin.Id == id)
            {
                return skin;
            }
        }

        return null;
    }
}
