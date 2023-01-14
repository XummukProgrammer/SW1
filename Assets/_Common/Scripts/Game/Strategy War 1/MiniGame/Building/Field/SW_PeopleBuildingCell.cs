public class SW_PeopleBuildingCell : SW_BuildingCell
{
    protected override void OnHourChanged()
    {
        base.OnHourChanged();

        MiniGame.PeopleComponent.AddPeople(100);
    }
}
