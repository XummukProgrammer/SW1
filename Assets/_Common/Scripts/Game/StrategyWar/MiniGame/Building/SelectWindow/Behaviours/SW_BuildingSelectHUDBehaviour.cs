using UnityEngine;

public class SW_BuildingSelectHUDBehaviour : HUDBehaviour
{
    public event System.Action OpenBuildingWindowButtonClicked;

    public void OnOpenBuildingWindowButtonClick()
    {
        OpenBuildingWindowButtonClicked?.Invoke();
    }
}
