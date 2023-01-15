using UnityEngine;

public class SW_BuildingCell : Cell
{
    private SW_MiniGame _miniGame;

    protected SW_MiniGame MiniGame => _miniGame;

    public override void OnStart()
    {
        base.OnInit();

        var miniGame = EntryPoint.CurrentMiniGame;
        if (miniGame is SW_MiniGame)
        {
            _miniGame = miniGame as SW_MiniGame;
            _miniGame.HourChanged += OnHourChanged;
        }
        else
        {
            Debug.Log("[SW] No found MiniGame: SW_MiniGame!");
        }
    }

    protected override void OnRemove()
    {
        base.OnRemove();

        _miniGame.HourChanged -= OnHourChanged;
    }

    public override bool CanShowContextMenu() { return true; }

    protected virtual void OnHourChanged() { }
}
