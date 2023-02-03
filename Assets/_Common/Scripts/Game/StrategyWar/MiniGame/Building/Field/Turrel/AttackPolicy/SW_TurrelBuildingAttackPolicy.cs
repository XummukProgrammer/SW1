using UnityEngine;

public class SW_TurrelBuildingAttackPolicy
{
    private SW_TurrelBuildingCell _turrelCell;
    private Transform _target;

    protected SW_TurrelBuildingCell TurrelCell => _turrelCell;
    protected Transform Target => _target;

    public void Init(SW_TurrelBuildingCell turrelCell)
    {
        _turrelCell = turrelCell;

        OnInit();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        OnChangeTarget();
    }

    public virtual void OnInit() { }
    public virtual bool CanAttack() { return false; }
    public virtual void Attack() { }
    public virtual bool IsTargetRemove() { return false; }
    protected virtual void OnChangeTarget() { }
}
