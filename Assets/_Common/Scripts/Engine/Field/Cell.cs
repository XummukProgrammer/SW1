using UnityEngine;

public class Cell
{
    private int _x;
    private int _y;
    private int _layer;
    private Vector2 _size;
    private EntryPoint _entryPoint;

    private CellBehaviour _behaviour;

    public int X => _x;
    public int Y => _y;
    public int Layer => _layer;
    public int Width => _x + (int)_size.x;
    public int Height => _y + (int)_size.y;
    public CellBehaviour Behaviour => _behaviour;
    protected EntryPoint EntryPoint => _entryPoint;

    public void Init(EntryPoint entryPoint, Transform container, CellBehaviour prefab, int x, int y, int layer, int width, int height, Vector2 startPosition)
    {
        _entryPoint = entryPoint;
        _x = x;
        _y = y;
        _layer = layer;

        _behaviour = GameObject.Instantiate(prefab, container);
        _behaviour.Init(this, $"Cell_{x}x{y}", x, y, width, height, startPosition);

        _size = _behaviour.Size;

        OnInit();
    }

    public void Remove()
    {
        OnRemove();

        if (!_entryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }
        
        _behaviour = null;
    }

    protected virtual void OnInit() { }
    protected virtual void OnRemove() { }
    public virtual void OnStart() { }
    public virtual void OnClicked() { }
    public virtual bool CanShowContextMenu() { return false; }
    public virtual void OnShowContextMenu() { }
}
