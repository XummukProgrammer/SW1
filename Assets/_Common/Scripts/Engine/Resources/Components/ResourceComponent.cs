using UnityEngine;

public class ResourceComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private string _name = "Coins";
    [SerializeField] private int _startValue = 1000;
    [SerializeField] private int _minValue = 100;
    [SerializeField] private int _maxValue = 1000;

    private ResourceHolder _resourceHolder = new ResourceHolder();

    public Resource Resource => _resourceHolder != null ? _resourceHolder.Resource : null;

    protected override void OnInit()
    {
        base.OnInit();

        _resourceHolder.Create(MiniGame, GetTargetObject(), _name, _startValue, _minValue, _maxValue, GetChangePolicy());
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        _resourceHolder.Remove();
    }

    protected virtual ResourceChangePolicy GetChangePolicy() { return null; }
    protected virtual string GetTargetObject() { return ""; }
}
