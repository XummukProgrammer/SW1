using UnityEngine;

// TODO: use MiniGame in children class?
public class Resource
{
    public System.Action<int> ValueChanged;
    public System.Action<int, int> ValueGived;
    public System.Action<int, int> ValueTaked;

    private MiniGame _miniGame;
    private string _name;
    private int _value;
    private int _minValue;
    private int _maxValue;
    private ResourceChangePolicy _changePolicy;

    public string Name => _name;

    public void Init(MiniGame miniGame, string name, int startValue, int minValue, int maxValue, ResourceChangePolicy changePolicy)
    {
        _miniGame = miniGame;
        _name = name;
        _value = startValue;
        _minValue = minValue;
        _maxValue = maxValue;
        _changePolicy = changePolicy;

        _changePolicy.Init(_miniGame);
    }

    public void Deinit()
    {
        _changePolicy.OnDeinit();
    }

    public void Update()
    {
        int diffValue = 0;

        if (_changePolicy.CanGiveValue())
        {
            diffValue = _changePolicy.GetGiveValue();
        }
        else if (_changePolicy.CanTakeValue()) 
        {
            diffValue -= _changePolicy.GetTakeValue();
        }

        if (diffValue != 0)
        {
            _value = Mathf.Clamp(_value + diffValue, _minValue, _maxValue);
            ValueChanged?.Invoke(_value);

            int absoluteDiffValue = Mathf.Abs(diffValue);

            if (diffValue > 0)
            {
                ValueGived?.Invoke(_value, absoluteDiffValue);
            }
            else if (diffValue < 0)
            {
                ValueTaked?.Invoke(_value, absoluteDiffValue);
            }

            _changePolicy.OnValueChanged();
        }
    }
}
