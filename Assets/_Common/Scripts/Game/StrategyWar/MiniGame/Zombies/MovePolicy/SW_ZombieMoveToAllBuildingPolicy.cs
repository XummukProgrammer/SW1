using UnityEngine;

public class SW_ZombieMoveToAllBuildingPolicy : SW_ZombieMovePolicy
{
    private SW_BuildingCell _targetCell;

    public override void FindObject()
    {
        base.FindObject();

        var cells = MiniGame.BuildingComponent.GetCells();
        int count = cells.Count;

        if (count > 0)
        {
            _targetCell = cells[Random.Range(0, count - 1)];
        }
    }

    public override bool IsChangeObject() 
    { 
        return false; 
    }

    public override Transform GetObject() 
    { 
        return _targetCell != null ? _targetCell.Behaviour.transform : null; 
    }
}
