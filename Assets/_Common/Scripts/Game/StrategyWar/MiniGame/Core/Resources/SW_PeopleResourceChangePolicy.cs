public class SW_PeopleResourceChangePolicy : ResourceChangePolicy
{
    private SW_MiniGame _miniGame;
    private bool _canGiveValue;

    public override void OnInit() 
    {
        base.OnInit();

        _miniGame = MiniGame as SW_MiniGame;
        _miniGame.HourChanged += OnHourChanged;

        _canGiveValue = false;
    }

    public override void OnDeinit() 
    { 
        base.OnDeinit();

        _miniGame.HourChanged -= OnHourChanged;
    }

    public override bool CanGiveValue() 
    { 
        return _canGiveValue; 
    }

    public override int GetGiveValue() 
    {
        int value = _miniGame.PeopleResourceComponent.BaseAddPeopleOnHour;

        var cells = _miniGame.FieldComponent.Field.GetCellsByType<SW_PeopleBuildingCell>();
        foreach (var cell in cells)
        {
            value += cell.GetAddPeople();
        }

        return value; 
    }

    public override bool CanTakeValue() 
    { 
        return false; 
    }

    public override int GetTakeValue() 
    { 
        return 0; 
    }

    public override void OnValueChanged() 
    { 
        base.OnValueChanged();

        _canGiveValue = false;
    }

    private void OnHourChanged()
    {
        _canGiveValue = true;
    }
}
