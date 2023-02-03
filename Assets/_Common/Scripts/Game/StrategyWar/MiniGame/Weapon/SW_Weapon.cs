using UnityEngine;

public class SW_Weapon
{
    private SW_WeaponBehaviour _prefab;
    private Transform _attached;
    private float _reloadTime;
    private float _reloadMaxTime;
    private Transform _target;

    private SW_WeaponBehaviour _behaviour;

    public bool IsReloaded => _reloadTime <= 0;

    public void Init(SW_WeaponBehaviour prefab, Transform attached, float reloadMaxTime)
    {
        _prefab = prefab;
        _attached = attached;
        _reloadMaxTime = reloadMaxTime;
        _reloadTime = 0;

        _behaviour = GameObject.Instantiate(_prefab, attached.transform);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void TryShot()
    {
        if (_behaviour == null || !IsReloaded)
        {
            return;
        }

        _reloadTime = _reloadMaxTime;

        //var bulletPosition = _behaviour.transform.position;
        //var targetPosition = target.transform.position;
    }

    public void Update(float dt)
    {
        ReloadProcess(dt);
        MoveToTargetProcess();
    }

    private void ReloadProcess(float dt)
    {
        // TODO: use timer?
        if (!IsReloaded)
        {
            _reloadTime -= dt;

            if (_reloadTime < 0)
            {
                _reloadTime = 0;
            }
        }
    }

    private void MoveToTargetProcess()
    {
    }
}
