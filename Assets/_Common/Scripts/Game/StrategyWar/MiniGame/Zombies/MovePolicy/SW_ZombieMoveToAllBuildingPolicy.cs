using UnityEngine;

public class SW_ZombieMoveToAllBuildingPolicy : SW_ZombieMovePolicy
{
    private SW_BuildingCell _targetCell;

    public override bool TryFindObject()
    {
        base.TryFindObject();

        var cells = Zombie.MiniGame.BuildingComponent.GetCells();
        int count = cells.Count;

        if (count > 0)
        {
            float minDistance = Vector3.Distance(Zombie.Behaviour.transform.position, cells[0].Behaviour.transform.position);
            _targetCell = cells[0];

            foreach (var cell in cells)
            {
                float distance = Vector3.Distance(Zombie.Behaviour.transform.position, cell.Behaviour.transform.position);
                if (minDistance > distance)
                {
                    minDistance = distance;
                    _targetCell = cell;
                }
            }

            _targetCell.Removed += OnCellRemoved;

            return true;
        }

        return false;
    }

    public override bool IsChangeObject() 
    { 
        return _targetCell == null; 
    }

    public override bool IsStop()
    {
        if (_targetCell == null)
        {
            return false;
        }

        var zombiePosition = Zombie.Behaviour.transform.position;
        var zombieScale = Zombie.Behaviour.transform.localScale;
        
        var cellPosition = _targetCell.Behaviour.transform.position;
        var cellScale = _targetCell.Behaviour.transform.localScale;

        if (IntersectsUtils.IsRectsTouched(zombiePosition, zombieScale, cellPosition, cellScale))
        {
            return true;
        }

        return false;
    }

    public override Transform GetObject() 
    { 
        return _targetCell != null ? _targetCell.Behaviour.transform : null; 
    }

    private void OnCellRemoved()
    {
        _targetCell.Removed -= OnCellRemoved;
        _targetCell = null;
    }
}
