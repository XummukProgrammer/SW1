public class SW_BuildingItemAction : SequenceAction
{
    private SW_MiniGame _miniGame;

    public void InitActions(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;

        AddAction(GetHideBuildingSelectHUDAction());
        AddAction(_miniGame.BuildingSelectWindowComponent.Controller.GetOpenAction());
        AddAction(_miniGame.BuildingCoordinatesWindowComponent.Controller.GetOpenAction());
        AddAction(GetShowBuildingSelectHUDAction());
    }

    private Action GetHideBuildingSelectHUDAction()
    {
        var action = new Action();
        action.ExecuteDelegate = () =>
        {
            _miniGame.BuildingSelectHUDComponent.Hide();
        };
        return action;
    }

    private Action GetShowBuildingSelectHUDAction()
    {
        var action = new Action();
        action.ExecuteDelegate = () =>
        {
            _miniGame.BuildingSelectHUDComponent.Show();
        };
        return action;
    }
}
