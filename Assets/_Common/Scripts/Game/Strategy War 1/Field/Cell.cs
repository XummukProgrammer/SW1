using UnityEngine;

public class Cell
{
    private int _x;
    private int _y;
    private EntryPoint _entryPoint;

    private CellBehaviour _behaviour;

    public int X => _x;
    public int Y => _y;

    public void Init(EntryPoint entryPoint, Transform container, CellBehaviour prefab, int x, int y, int width, int height, Vector2 startPosition)
    {
        _entryPoint = entryPoint;
        _x = x;
        _y = y;

        _behaviour = GameObject.Instantiate(prefab, container);
        _behaviour.Init(x, y, width, height, startPosition);

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
}
