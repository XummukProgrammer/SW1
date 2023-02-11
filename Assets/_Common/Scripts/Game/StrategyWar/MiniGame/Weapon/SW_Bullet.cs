using UnityEngine;

public class SW_Bullet
{
    private SW_MiniGame _miniGame;
    private SW_TurrelBuildingCell _turrelCell;
    private SW_BulletBehaviour _prefab;
    private float _speed;
    private Vector2 _startPosition;
    private Vector3 _direction;
    private Transform _container;

    private SW_BulletBehaviour _behaviour;

    public void Init(SW_MiniGame miniGame, SW_TurrelBuildingCell turrelCell, SW_BulletBehaviour prefab, float speed, Vector2 startPosition, Vector3 direction, Transform container)
    {
        _miniGame = miniGame;
        _turrelCell = turrelCell;
        _prefab = prefab;
        _speed = speed;
        _startPosition = startPosition;
        _direction = direction;
        _container = container;

        Create();
    }

    public void Deinit()
    {
        if (!_miniGame.EntryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }

        _behaviour = null;
    }

    public void Update(float dt)
    {
        var position = _behaviour.transform.position;
        _behaviour.transform.position = Vector3.MoveTowards(position, position + _direction, _speed * Time.deltaTime);

        foreach (var zombie in _miniGame.ZombiesComponent.Zombies.Zombies)
        {
            if (IntersectsUtils.IsRectsTouched(_behaviour.transform.position, _behaviour.transform.localScale, zombie.Behaviour.transform.position, zombie.Behaviour.transform.localScale))
            {
                _miniGame.ZombiesComponent.Zombies.RemoveZombie(zombie);
                _turrelCell.OnFindObject();
                break;
            }
        }
    }

    private void Create()
    {
        _behaviour = GameObject.Instantiate(_prefab, _container);
        _behaviour.transform.position = _startPosition;
    }
}
