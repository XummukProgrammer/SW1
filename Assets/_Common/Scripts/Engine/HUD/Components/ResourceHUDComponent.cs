using UnityEngine;

public class ResourceHUDComponent<T> : HUDComponent<HUD, T> where T : MiniGame
{
    [SerializeField] private string _name = "Coins";

    private Resource _resource;

    protected override void OnPostInit()
    {
        base.OnPostInit();

        _resource = MiniGame.EntryPoint.ResourcesManager.GetResourceByName(GetTargetObject(), _name);
        if (_resource != null)
        {
            _resource.ValueChanged += OnChangeValue;
        }
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (_resource != null)
        {
            _resource.ValueChanged -= OnChangeValue;

            _resource = null;
        }
    }

    private void OnChangeValue(int value)
    {
        if (Controller.Behaviour.TryGetComponent(out ResourceHUDBehaviour behaviour))
        {
            behaviour.SetValue(value);
        }
    }

    protected virtual string GetTargetObject() { return ""; }
}
