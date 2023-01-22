public class SW_ZombieAttackPolicy
{
    private SW_Zombie _zombie;

    protected SW_Zombie Zombie => _zombie;

    public void Init(SW_Zombie zombie)
    {
        _zombie = zombie;
    }

    public virtual bool CanAttack() { return false; }
    public virtual void Attack() { }
    public virtual bool IsTargetRemoved() { return false; }
}
