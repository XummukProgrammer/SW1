using UnityEngine;
using UnityEngine.EventSystems;

public class SW_Zombie
{
    private SW_MiniGame _miniGame;
    private Transform _container;
    private SW_ZombieBehaviour _behaviour;
    private SW_ZombieBehaviour _prefab;
    private SW_ZombieMovePolicy _movePolicy;
    private Transform _moveTarget;
    private SW_ZombieAttackPolicy _attackPolicy;

    public SW_MiniGame MiniGame => _miniGame;
    public SW_ZombieBehaviour Behaviour => _behaviour;

    public SW_ZombieMovePolicy MovePolicy => _movePolicy;
    public SW_ZombieAttackPolicy AttackPolicy => _attackPolicy;

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

    public void SetMovePolicy(SW_ZombieMovePolicy movePolicy)
    {
        _movePolicy = movePolicy;
    }

    public void SetAttackPolicy(SW_ZombieAttackPolicy attackPolicy)
    {
        _attackPolicy = attackPolicy;
    }

    public void Init()
    {
        if (_movePolicy == null)
        {
            _movePolicy = CreateMovePolicy();
        }

        if (_attackPolicy == null)
        {
            _attackPolicy = CreateAttackPolicy();
        }

        _movePolicy.Init(this);
        _attackPolicy.Init(this);

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
            if (_moveTarget == null)
            {
                OnInitMoveObject();
            }
            else if (_movePolicy.IsChangeObject())
            {
                OnInitMoveObject();
            }
            else if (!_movePolicy.IsStop())
            {
                MoveToObject();
            }
            else
            {
                AttackObject();
            }
        }

        OnUpdate();
    }

    public void Create()
    {
        _behaviour = GameObject.Instantiate(_prefab, _container);
        _behaviour.Init(this);
        OnCreate();
    }

    public void SetPosition(float x, float y)
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

        if (_movePolicy.TryFindObject())
        {
            _moveTarget = _movePolicy.GetObject();
        }
        else
        {
            _movePolicy = null;
            _moveTarget = null;
        }
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
            _behaviour.transform.position = Vector3.MoveTowards(_behaviour.transform.position, targetObject.transform.position, 3f * Time.deltaTime);
        }
    }

    private void AttackObject()
    {
        if (_attackPolicy == null)
        {
            return;
        }

        if (_attackPolicy.CanAttack())
        {
            _attackPolicy.Attack();

            if (_attackPolicy.IsTargetRemoved())
            {
                OnInitMoveObject();
            }
        }
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnCreate() { }
    protected virtual void OnRemove() { }

    protected virtual SW_ZombieMovePolicy CreateMovePolicy() { return null; }
    protected virtual SW_ZombieAttackPolicy CreateAttackPolicy() { return null; }
}
