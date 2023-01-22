using UnityEngine;

public class SW_Zombie
{
    private SW_MiniGame _miniGame;
    private Transform _container;
    private SW_ZombieBehaviour _behaviour;
    private SW_ZombieBehaviour _prefab;
    private SW_ZombieMovePolicy _movePolicy;
    private Transform _moveTarget;

    protected SW_MiniGame MiniGame => _miniGame;
    
    public void SetMiniGame(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;
    }

    public void SetPrefab(SW_ZombieBehaviour prefab)
    {
        _prefab = prefab;
    }

    public void SetContainer(Transform container)
    {
        _container = container;
    }

    public void Init()
    {
        _movePolicy = CreateMovePolicy();
        _movePolicy.Init(_miniGame);

        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
    }

    public void Update()
    {
        if (_movePolicy != null)
        {
            var position = _behaviour.transform.position;
            _movePolicy.SetPosition(position.x, position.y);

            if (_moveTarget == null)
            {
                OnInitMoveObject();
            }
            else if (_movePolicy.IsChangeObject())
            {
                OnInitMoveObject();
            }

            MoveToObject();
        }

        OnUpdate();
    }

    public void Create()
    {
        _behaviour = GameObject.Instantiate(_prefab, _container);
        OnCreate();
    }

    public void SetPosition(int x, int y)
    {
        _behaviour.transform.position = new Vector3(x, y, _behaviour.transform.position.z);
    }

    public void Remove()
    {
        OnRemove();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }
        
        _behaviour = null;
    }

    private void OnInitMoveObject()
    {
        if (_movePolicy == null)
        {
            return;
        }

        _movePolicy.FindObject();
        _moveTarget = _movePolicy.GetObject();
    }

    private void MoveToObject()
    {
        if (_movePolicy == null)
        {
            return;
        }

        var targetObject = _movePolicy.GetObject();
        if (targetObject != null)
        {
            _behaviour.transform.position = Vector3.MoveTowards(_behaviour.transform.position, targetObject.transform.position, 0.01f);
        }
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnCreate() { }
    protected virtual void OnRemove() { }

    protected virtual SW_ZombieMovePolicy CreateMovePolicy() { return new SW_ZombieMoveToAllBuildingPolicy(); }
}
