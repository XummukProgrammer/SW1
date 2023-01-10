using UnityEngine;

public class SW_SkinsComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_CellSkin[] _cellSkins;

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
}
