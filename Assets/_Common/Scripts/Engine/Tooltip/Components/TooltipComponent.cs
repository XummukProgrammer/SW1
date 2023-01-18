using UnityEngine;

public class TooltipComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private TooltipBehaviour _prefab;
    [SerializeField] private bool _isAutoShow;
    [SerializeField] private string _targetLocator;

    private Tooltip _tooltip;

    public void Create()
    {
        _tooltip = MiniGame.EntryPoint.TooltipManager.CreateTooltip(_prefab, GetTarget(), _isAutoShow);
        OnCreate();
    }

    public void Remove()
    {
        _tooltip.Remove();
        _tooltip = null;
        OnRemove();
    }

    public void Show()
    {
        _tooltip.Show();
        OnShow();
    }

    public void Hide()
    {
        _tooltip.Hide();
        OnHide();
    }

    private Transform GetTargetWithLocator()
    {
        var locator = MiniGame.EntryPoint.LocatorManager.GetLocatorByName(_targetLocator);
        if (locator != null)
        {
            return locator.Behaviour.transform;
        }
        return null;
    }

    protected virtual void OnCreate() { }
    protected virtual void OnRemove() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }

    protected private Transform GetTarget() { return GetTargetWithLocator(); }
}
