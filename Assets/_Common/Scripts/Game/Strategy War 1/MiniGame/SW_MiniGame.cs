using UnityEngine;

public class SW_MiniGame : MiniGame
{
    public event System.Action<Cell> CellClicked;

    private SW_FieldComponent _fieldComponent;
    private SW_SkinsComponent _skinsComponent;
    private SW_BuildingComponent _buildingComponent;

    public SW_FieldComponent FieldComponent => GetFieldComponent();
    public SW_SkinsComponent SkinsComponent => GetSkinsComponent();
    public SW_BuildingComponent BuildingComponent => GetBuildingComponent();

    protected override void OnInit() 
    { 
        base.OnInit();

        Debug.Log("[SW] MiniGame started!");
    }

    protected override void OnPostInit() 
    { 
        base.OnPostInit();
    }

    protected override void OnDeinit() 
    { 
        base.OnDeinit();
    }

    protected override void OnUpdate() 
    { 
        base.OnUpdate();
    }

    protected override void OnLoadResources() 
    {
        base.OnLoadResources();
    }

    protected override void OnUnloadResources() 
    { 
        base.OnUnloadResources();
    }

    protected override void OnInProgress() 
    { 
        base.OnInProgress();
    }

    protected override void OnWin() 
    { 
        base.OnWin();
    }

    protected override void OnShowWinWindow() 
    { 
        base.OnShowWinWindow();
    }

    protected override void OnLose() 
    { 
        base.OnLose();
    }

    protected override void OnShowLoseWindow() 
    { 
        base.OnShowLoseWindow();
    }

    protected override void OnShowRewardWindow() 
    {
        base.OnShowRewardWindow();
    }

    protected override void OnDisable() 
    {
        base.OnDisable();
    }

    protected override bool IsResourcesLoaded() 
    { 
        return true; 
    }

    protected override bool IsResourcesUnloaded() 
    { 
        return true; 
    }

    protected override bool IsWin() 
    { 
        return false; 
    }

    protected override bool IsLose() 
    { 
        return false; 
    }

    protected override bool IsWinWindowShowed() 
    { 
        return false; 
    }

    protected override bool IsLoseWindowShowed() 
    { 
        return false; 
    }

    protected override bool IsRewardWindowShowed() 
    { 
        return false; 
    }

    private SW_FieldComponent GetFieldComponent()
    {
        if (_fieldComponent == null)
        {
            _fieldComponent = Components.GetComponentInChildren<SW_FieldComponent>();
        }

        return _fieldComponent;
    }

    private SW_SkinsComponent GetSkinsComponent()
    {
        if (_skinsComponent == null)
        {
            _skinsComponent = Components.GetComponentInChildren<SW_SkinsComponent>();
        }

        return _skinsComponent;
    }

    private SW_BuildingComponent GetBuildingComponent()
    {
        if (_buildingComponent == null)
        {
            _buildingComponent = Components.GetComponentInChildren<SW_BuildingComponent>();
        }

        return _buildingComponent;
    }

    public void OnPlayerCellClicked(Cell cell)
    {
        CellClicked?.Invoke(cell);
    }
}
