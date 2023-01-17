using UnityEngine;

public class Tooltip
{
    private EntryPoint _entryPoint;
    private TooltipBehaviour _behaviour;
    private Transform _target;

    public EntryPoint EntryPoint => _entryPoint;

    public void Create(EntryPoint entryPoint, TooltipBehaviour prefab, Transform container, Transform target, bool isAutoShow)
    {
        _entryPoint = entryPoint;
        _target = target;
        _behaviour = GameObject.Instantiate(prefab, container);
        OnCreate();
        _behaviour.OnCreate();

        if (isAutoShow)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    public void Remove()
    {
        OnRemove();
        _behaviour.OnRemove();
        GameObject.Destroy(_behaviour.gameObject);
        _behaviour = null;
    }

    public void Show()
    {
        CalculatePositionWithTarget();
        OnShow();
        _behaviour.OnShow();
    }

    public void Hide()
    {
        OnHide();
        _behaviour.OnHide();
    }

    private void CalculatePositionWithTarget()
    {
        _behaviour.transform.position = _target.position;
    }

    protected virtual void OnCreate() { }
    protected virtual void OnRemove() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
