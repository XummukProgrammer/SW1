using UnityEngine;

public class SW_TurrelBuildingVisionPolicy
{
    private SW_TurrelBuildingCell _turrelCell;

    protected SW_TurrelBuildingCell TurrelCell => _turrelCell;

    public void Init(SW_TurrelBuildingCell turrelCell)
    {
        _turrelCell = turrelCell;
    }

    public virtual void FindObject() { }
    public virtual Transform GetObject() { return null; }
    public virtual bool IsObjectValid() { return false; }
}
