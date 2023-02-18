using UnityEngine;

public class SW_MiniGame : MiniGame
{
    public event System.Action<Cell> CellClicked;
    public event System.Action HourChanged;

    private SW_FieldComponent _fieldComponent;
    private SW_SkinsComponent _skinsComponent;
    private SW_BuildingComponent _buildingComponent;
    private SW_BuildingContextMenuComponent _buildingContextMenuComponent;
    private SW_ZombiesComponent _zombiesComponent;
    private SW_PeopleResourceComponent _peopleResourceComponent;
    private SW_WeaponsDataComponent _weaponsDataComponent;
    private SW_BulletsDataComponent _bulletsDataComponent;
    private SW_BuildingSelectWindowComponent _buildingSelectWindowComponent;
    private SW_BuildingSelectHUDComponent _buildingSelectHUDComponent;
    private SW_BuildingCoordinatesWindowComponent _buildingCoordinatesWindowComponent;

    public SW_FieldComponent FieldComponent => GetFieldComponent();
    public SW_SkinsComponent SkinsComponent => GetSkinsComponent();
    public SW_BuildingComponent BuildingComponent => GetBuildingComponent();
    public SW_BuildingContextMenuComponent BuildingContextMenuComponent => GetBuildingContextMenuComponent();
    public SW_ZombiesComponent ZombiesComponent => GetZombiesComponent();
    public SW_PeopleResourceComponent PeopleResourceComponent => GetPeopleResourceComponent();
    public SW_WeaponsDataComponent WeaponsDataComponent => GetWeaponsDataComponent();
    public SW_BulletsDataComponent BulletsDataComponent => GetBulletsDataComponent();
    public SW_BuildingSelectWindowComponent BuildingSelectWindowComponent => GetBuildingSelectWindowComponent();
    public SW_BuildingSelectHUDComponent BuildingSelectHUDComponent => GetBuildingSelectHUDComponent();
    public SW_BuildingCoordinatesWindowComponent BuildingCoordinatesWindowComponent => GetBuildingCoordinatesWindowComponent();

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

    private SW_BuildingContextMenuComponent GetBuildingContextMenuComponent()
    {
        if (_buildingContextMenuComponent == null)
        {
            _buildingContextMenuComponent = Components.GetComponentInChildren<SW_BuildingContextMenuComponent>();
        }

        return _buildingContextMenuComponent;
    }

    private SW_ZombiesComponent GetZombiesComponent()
    {
        if (_zombiesComponent == null)
        {
            _zombiesComponent = Components.GetComponentInChildren<SW_ZombiesComponent>();
        }

        return _zombiesComponent;
    }

    private SW_PeopleResourceComponent GetPeopleResourceComponent()
    {
        if (_peopleResourceComponent == null)
        {
            _peopleResourceComponent = Components.GetComponentInChildren<SW_PeopleResourceComponent>();
        }

        return _peopleResourceComponent;
    }

    private SW_WeaponsDataComponent GetWeaponsDataComponent()
    {
        if (_weaponsDataComponent == null)
        {
            _weaponsDataComponent = Components.GetComponentInChildren<SW_WeaponsDataComponent>();
        }

        return _weaponsDataComponent;
    }

    private SW_BulletsDataComponent GetBulletsDataComponent()
    {
        if (_bulletsDataComponent == null)
        {
            _bulletsDataComponent = Components.GetComponentInChildren<SW_BulletsDataComponent>();
        }

        return _bulletsDataComponent;
    }

    private SW_BuildingSelectWindowComponent GetBuildingSelectWindowComponent()
    {
        if (_buildingSelectWindowComponent == null)
        {
            _buildingSelectWindowComponent = Components.GetComponentInChildren<SW_BuildingSelectWindowComponent>();
        }

        return _buildingSelectWindowComponent;
    }

    private SW_BuildingSelectHUDComponent GetBuildingSelectHUDComponent()
    {
        if (_buildingSelectHUDComponent == null)
        {
            _buildingSelectHUDComponent = Components.GetComponentInChildren<SW_BuildingSelectHUDComponent>();
        }

        return _buildingSelectHUDComponent;
    }

    private SW_BuildingCoordinatesWindowComponent GetBuildingCoordinatesWindowComponent()
    {
        if (_buildingCoordinatesWindowComponent == null)
        {
            _buildingCoordinatesWindowComponent = Components.GetComponentInChildren<SW_BuildingCoordinatesWindowComponent>();
        }

        return _buildingCoordinatesWindowComponent;
    }

    public void OnPlayerCellClicked(Cell cell)
    {
        cell.OnClicked();
        CellClicked?.Invoke(cell);
    }

    public void OnCellShowContextMenu(Cell cell)
    {
        cell.OnShowContextMenu();
    }

    public void OnHourChanged()
    {
        HourChanged?.Invoke();
    }
}
