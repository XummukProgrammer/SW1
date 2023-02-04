using UnityEngine;

public class SW_TurrelBuildingWeaponAttackPolicy : SW_TurrelBuildingAttackPolicy
{
    private SW_Weapon _weapon = new SW_Weapon();
    private SW_Zombie _targetZombie; // TODO: delete?

    public override void OnInit()
    {
        base.OnInit();

        var weaponData = TurrelCell.MiniGame.WeaponsDataComponent.GetData(TurrelCell.WeaponName);
        if (weaponData == null)
        {
            Debug.Log("[SW] No found weapon: " + TurrelCell.WeaponName);
            return;
        }

        var bulletData = TurrelCell.MiniGame.BulletsDataComponent.GetData(weaponData.BulletName);
        if (bulletData == null)
        {
            Debug.Log("[SW] No found bullet: " + weaponData.BulletName + " for weapon: " + TurrelCell.WeaponName);
            return;
        }

        var bulletsLocator = TurrelCell.MiniGame.EntryPoint.LocatorManager.GetLocatorByName("Bullets");
        if (bulletsLocator == null)
        {
            Debug.Log("[SW] No found locator: Bullets");
            return;
        }

        _weapon.Init(TurrelCell.MiniGame.EntryPoint, weaponData.Prefab, TurrelCell.Behaviour.transform, weaponData.ReloadMaxTime, bulletData, bulletsLocator.Behaviour.transform);
    }

    public override bool CanAttack() 
    {
        _weapon.Update(Time.deltaTime);
        return _weapon.IsReloaded; 
    }

    public override void Attack() 
    {
        base.Attack();

        if (_weapon.TryShot())
        {

        }
    }

    public override bool IsTargetRemove() 
    { 
        return false; 
    }

    protected override void OnChangeTarget()
    {
        base.OnChangeTarget();

        if (Target)
        {
            if (Target.TryGetComponent(out SW_ZombieBehaviour behaviour))
            {
                _targetZombie = behaviour.Zombie;
                _weapon.SetTarget(Target);
            }
            else
            {
                _targetZombie = null;
            }
        }
        else
        {
            _targetZombie = null;
        }
    }
}
