using UnityEngine;

public class SW_ZombieMovePolicy
{
    private SW_MiniGame _miniGame;
    private Vector2 _currentPosition;

    protected SW_MiniGame MiniGame => _miniGame;

    public void Init(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;
    }

    public void SetPosition(float x, float y)
    {
        _currentPosition = new Vector2(x, y);
    }

    public virtual void FindObject() { }
    public virtual bool IsChangeObject() { return false; }
    public virtual Transform GetObject() { return null; }
}
