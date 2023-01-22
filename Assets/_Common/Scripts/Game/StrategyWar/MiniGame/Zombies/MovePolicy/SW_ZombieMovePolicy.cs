using UnityEngine;

public class SW_ZombieMovePolicy
{
    private SW_MiniGame _miniGame;
    private SW_Zombie _zombie;

    protected SW_MiniGame MiniGame => _miniGame;
    protected SW_Zombie Zombie => _zombie;

    public void Init(SW_MiniGame miniGame, SW_Zombie zombie)
    {
        _miniGame = miniGame;
        _zombie = zombie;
    }

    public virtual void FindObject() { }
    public virtual bool IsChangeObject() { return false; }
    public virtual bool IsStop() { return false; }
    public virtual Transform GetObject() { return null; }
}
