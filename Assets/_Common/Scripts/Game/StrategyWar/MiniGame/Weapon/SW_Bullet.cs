using UnityEngine;

public class SW_Bullet
{
    private EntryPoint _entryPoint;
    private SW_BulletBehaviour _prefab;
    private float _speed;
    private Vector2 _startPosition;
    private Vector3 _direction;
    private Transform _container;

    private SW_BulletBehaviour _behaviour;

    public void Init(EntryPoint entryPoint, SW_BulletBehaviour prefab, float speed, Vector2 startPosition, Vector3 direction, Transform container)
    {
        _entryPoint = entryPoint;
        _prefab = prefab;
        _speed = speed;
        _startPosition = startPosition;
        _direction = direction;
        _container = container;

        Create();
    }

    public void Deinit()
    {
        if (!_entryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }

        _behaviour = null;
    }

    public void Update(float dt)
    {
        var position = _behaviour.transform.position;
        _behaviour.transform.position = Vector3.MoveTowards(position, position + _direction, _speed);
    }

    private void Create()
    {
        _behaviour = GameObject.Instantiate(_prefab, _container);
        _behaviour.transform.position = _startPosition;
    }
}
