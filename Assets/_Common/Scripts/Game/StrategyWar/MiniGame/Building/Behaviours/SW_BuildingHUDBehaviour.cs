using UnityEngine;

public class SW_BuildingHUDBehaviour : HUDBehaviour
{
    public event System.Action OpenBuildingWindowButtonClicked;

    public void OnOpenBuildingWindowButtonClick()
    {
        OpenBuildingWindowButtonClicked?.Invoke();
    }
}
