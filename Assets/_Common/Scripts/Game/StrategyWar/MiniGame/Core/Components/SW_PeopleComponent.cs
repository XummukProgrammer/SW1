using UnityEngine;

public class SW_PeopleComponent : GameComponent<SW_MiniGame>
{
    public event System.Action<int> Changed;

    [SerializeField] private int _baseAddPeopleOnHour = 10;

    private int _people = 1000;

    public int People => _people;

    protected override void OnInit()
    {
        base.OnInit();

        MiniGame.HourChanged += OnHourChanged;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.HourChanged -= OnHourChanged;
    }

    public void AddPeople(int people)
    {
        _people += people;
        Changed?.Invoke(_people);
    }

    public void TakePeople(int people)
    {
        _people -= people;

        if (_people < 0)
        {
            _people = 0;
        }

        Changed?.Invoke(_people);
    }

    private void OnHourChanged()
    {
        AddPeople(_baseAddPeopleOnHour);
    }
}
