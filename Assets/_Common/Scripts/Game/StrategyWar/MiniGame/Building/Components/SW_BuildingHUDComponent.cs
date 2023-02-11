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
        MiniGame.BuildingWindowComponent.Controller.OpenByAction();
    }
}
