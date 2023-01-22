using UnityEngine;

public class SW_ZombieMovePolicy
{
    private SW_Zombie _zombie;

    protected SW_Zombie Zombie => _zombie;

    public void Init(SW_Zombie zombie)
    {
        _zombie = zombie;
    }

    public virtual bool TryFindObject() { return false; }
    public virtual bool IsChangeObject() { return false; }
    public virtual bool IsStop() { return false; }
    public virtual Transform GetObject() { return null; }
}
