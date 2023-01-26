public class SW_ResourceComponent : ResourceComponent<SW_MiniGame>
{
    protected override ResourceChangePolicy GetChangePolicy() { return new SW_PeopleResourceChangePolicy(); }
}
