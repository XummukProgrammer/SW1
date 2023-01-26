using UnityEngine;

public class SW_PeopleResourceComponent : ResourceComponent<SW_MiniGame>
{
    [SerializeField] private int _baseAddPeopleOnHour;

    public int BaseAddPeopleOnHour => _baseAddPeopleOnHour;

    protected override ResourceChangePolicy GetChangePolicy() { return new SW_PeopleResourceChangePolicy(); }
}
