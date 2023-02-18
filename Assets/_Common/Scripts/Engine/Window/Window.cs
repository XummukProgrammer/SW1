using UnityEngine;

public class Window : IController
{
    public event System.Action Created;
    public event System.Action Destroyed;

    private EntryPoint _entryPoint;
    private WindowBehaviour _prefab;
    private Transform _container;
    private WindowBehaviour _behaviour;
    private bool _isClose;

    public EntryPoint EntryPoint => _entryPoint;
    public WindowBehaviour Behaviour => _behaviour;

    public void InitWithParams(EntryPoint entryPoint, WindowBehaviour prefab, Transform container)
    {
        _entryPoint = entryPoint;
        _prefab = prefab;
        _container = container;
        _isClose = false;
    }

    public void Init()
    {
        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
    }

    public void Update()
    {
        OnUpdate();
    }

    public void Create()
    {
        _isClose = false;
        _behaviour = GameObject.Instantiate(_prefab, _container);
        OnCreate();
        _behaviour.Init();
        Created?.Invoke();
    }

    public void Destroy()
    {
        Destroyed?.Invoke();

        OnDestroy();
        _behaviour.Deinit();

        if (!_entryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }
    }

    public void Show()
    {
        _behaviour.Show();
        OnShow();
    }

    public void Hide()
    {
        _behaviour.Hide();
        OnHide();
    }

    public void OpenByAction()
    {
        EntryPoint.ActonsQueue.AddAction(GetOpenAction());
    }

    public WindowAction GetOpenAction()
    {
        var action = new WindowAction();
        action.Open(this);

        return action;
    }

    public void Close()
    {
        _isClose = true;
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnCreate() { }
    protected virtual void OnDestroy() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }

    public virtual bool IsClose() { return _isClose;  }
}
