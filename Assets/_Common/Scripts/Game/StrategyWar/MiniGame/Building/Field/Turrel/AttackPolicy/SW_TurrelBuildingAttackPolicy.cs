public class SW_TurrelBuildingAttackPolicy
{
    private SW_TurrelBuildingCell _turrelCell;

    protected SW_TurrelBuildingCell TurrelCell => _turrelCell;

    public void Init(SW_TurrelBuildingCell turrelCell)
    {
        _turrelCell = turrelCell;
    }

    public virtual bool CanAttack() { return false; }
    public virtual void Attack() { }
    public virtual bool IsTargetRemove() { return false; }
}
