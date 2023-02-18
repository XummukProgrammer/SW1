using UnityEngine;

public class SW_BuildingHUDComponent : HUDComponent<HUD, SW_MiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        if (Controller.Behaviour.TryGetComponent(out SW_BuildingHUDBehaviour behaviour))
        {
            behaviour.OpenBuildingWindowButtonClicked += OnBuildingWindowShow;
        }
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (Controller.Behaviour.TryGetComponent(out SW_BuildingHUDBehaviour behaviour))
        {
            behaviour.OpenBuildingWindowButtonClicked -= OnBuildingWindowShow;
        }
    }

    private void OnBuildingWindowShow()
    {
        var action = new SW_BuildingItemAction();
        action.InitActions(MiniGame);

        MiniGame.EntryPoint.ActonsQueue.AddAction(action);
    }
}
