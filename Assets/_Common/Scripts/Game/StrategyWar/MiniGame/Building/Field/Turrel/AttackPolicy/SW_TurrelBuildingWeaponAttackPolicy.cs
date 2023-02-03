using UnityEngine;

public class SW_TurrelBuildingWeaponAttackPolicy : SW_TurrelBuildingAttackPolicy
{
    private SW_Weapon _weapon = new SW_Weapon();
    private SW_Zombie _targetZombie;

    public override void OnInit()
    {
        base.OnInit();

        var weaponData = TurrelCell.MiniGame.WeaponsDataComponent.GetData(TurrelCell.WeaponName);
        if (weaponData != null )
        {
            _weapon.Init(weaponData.Prefab, TurrelCell.Behaviour.transform, weaponData.ReloadMaxTime);
        }
    }

    public override bool CanAttack() 
    {
        _weapon.Update(Time.deltaTime);
        return _weapon.IsReloaded; 
    }

    public override void Attack() 
    {
        base.Attack();

        _weapon.TryShot();
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
