using UnityEngine;

public class SW_BuildingCell : Cell
{
    private SW_MiniGame _miniGame;

    public SW_MiniGame MiniGame => _miniGame;

    public override void OnStart()
    {
        base.OnStart();

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

        if (this == _miniGame.BuildingContextMenuComponent.TargetCell)
        {
            _miniGame.BuildingContextMenuComponent.Remove();
        }
    }

    public override void OnShowContextMenu()
    {
        var buildingContextMenuComponent = _miniGame.BuildingContextMenuComponent;

        if (!buildingContextMenuComponent.IsCreated)
        {
            buildingContextMenuComponent.SetTargetCell(this);
            buildingContextMenuComponent.Create();
            buildingContextMenuComponent.Show();
        }
    }

    protected virtual void OnHourChanged() { }
}
