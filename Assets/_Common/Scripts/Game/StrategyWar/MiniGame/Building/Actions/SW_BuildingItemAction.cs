public class SW_BuildingItemAction : SequenceAction
{
    public void InitActions(SW_MiniGame miniGame)
    {
        AddAction(miniGame.BuildingSelectWindowComponent.Controller.GetOpenAction());
    }
}
