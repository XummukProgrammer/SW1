using System.Collections.Generic;
using UnityEngine;

public class SW_Weapon
{
    private SW_MiniGame _miniGame;
    private SW_TurrelBuildingCell _turrelCell;
    private SW_WeaponBehaviour _prefab;
    private Transform _attached;
    private float _reloadTime;
    private float _reloadMaxTime;
    private Transform _target;
    private SW_BulletData _bulletData;
    private List<SW_Bullet> _bullets = new List<SW_Bullet>();
    private Transform _bulletsContainer;

    private SW_WeaponBehaviour _behaviour;

    public bool IsReloaded => _reloadTime <= 0;

    public void Init(SW_MiniGame miniGame, SW_TurrelBuildingCell turrelCell, SW_WeaponBehaviour prefab, Transform attached, float reloadMaxTime, SW_BulletData bulletData, Transform bulletsContainer)
    {
        _miniGame = miniGame;
        _turrelCell = turrelCell;
        _prefab = prefab;
        _attached = attached;
        _reloadMaxTime = reloadMaxTime;
        _reloadTime = 0;
        _bulletData = bulletData;
        _bulletsContainer = bulletsContainer;

        _behaviour = GameObject.Instantiate(_prefab, _attached.transform);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public bool TryShot()
    {
        if (_behaviour == null || !IsReloaded || _target == null)
        {
            return false;
        }

        _reloadTime = _reloadMaxTime;

        CreateBullet();

        return true;
    }

    public void Update(float dt)
    {
        ReloadProcess(dt);
        MoveToTargetProcess();
        UpdateBullets(dt);
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
        if (_behaviour == null || _target == null)
        {
            return;
        }

        var direction = _target.position - _behaviour.transform.position;
        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _behaviour.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    private void CreateBullet()
    {
        var muzzlePosition = _behaviour.Muzzle;
        var targetPosition = _target.transform.position;
        var direction = targetPosition - _behaviour.transform.position;

        var bullet = new SW_Bullet();
        bullet.Init(_miniGame, _turrelCell, _bulletData.Prefab, _bulletData.Speed, muzzlePosition.position, direction, _bulletsContainer);
        _bullets.Add(bullet);
    }

    private void UpdateBullets(float dt)
    {
        foreach (var bullet in _bullets )
        {
            bullet.Update(dt);
        }
    }
}
