public class ResourceChangePolicy
{
    private MiniGame _miniGame;

    public void Init(MiniGame miniGame)
    {
        _miniGame = miniGame;
        OnInit();
    }

    public virtual void OnInit() { }
    public virtual void OnDeinit() { }

    public virtual bool CanGiveValue() { return false; }
    public virtual int GetGiveValue() { return 0; }

    public virtual bool CanTakeValue() { return false; }
    public virtual int GetTakeValue() { return 0; }

    public virtual void OnValueChanged() { }
}
