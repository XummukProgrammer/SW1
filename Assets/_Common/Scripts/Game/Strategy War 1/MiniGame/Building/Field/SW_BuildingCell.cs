using UnityEngine;

public class SW_BuildingCell : Cell
{
    private SW_MiniGame _miniGame;

    public override void OnStart()
    {
        base.OnInit();

        var miniGame = EntryPoint.CurrentMiniGame;
        if (miniGame is SW_MiniGame)
        {
            _miniGame = miniGame as SW_MiniGame;
        }
        else
        {
            Debug.Log("[SW] No found MiniGame: SW_MiniGame!");
        }
    }
}
