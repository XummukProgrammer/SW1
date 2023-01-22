using UnityEngine;

public class SW_Zombie
{
    private SW_MiniGame _miniGame;
    private Transform _container;
    private SW_ZombieBehaviour _behaviour;
    private SW_ZombieBehaviour _prefab;

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
        GameObject.Destroy(_behaviour.gameObject);
        _behaviour = null;
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnCreate() { }
    protected virtual void OnRemove() { }
}
