using UnityEngine;

public class ResourceComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private string _name = "Coins";
    [SerializeField] private int _startValue = 1000;
    [SerializeField] private int _minValue = 100;
    [SerializeField] private int _maxValue = 1000;

    private Resource _resource;

    protected override void OnInit()
    {
        base.OnInit();

        _resource = MiniGame.EntryPoint.ResourcesManager.AddResource(MiniGame, _name, _startValue, _minValue, _maxValue, GetChangePolicy());
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (_resource != null)
        {
            MiniGame.EntryPoint.ResourcesManager.RemoveResource(_resource);
            _resource = null;
        }
    }

    protected virtual ResourceChangePolicy GetChangePolicy() { return null; }
}
