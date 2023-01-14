public class SW_PeopleHUDComponent : HUDComponent<HUD, SW_MiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        MiniGame.PeopleComponent.Changed += OnPeopleChanged;
        OnPeopleChanged(MiniGame.PeopleComponent.People);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            MiniGame.PeopleComponent.Changed -= OnPeopleChanged;
        }
    }

    private void OnPeopleChanged(int people)
    {
        if (Controller.Behaviour.TryGetComponent(out SW_PeopleHUDBehaviour behaviour))
        {
            behaviour.SetPeople(people);
        }
    }
}
