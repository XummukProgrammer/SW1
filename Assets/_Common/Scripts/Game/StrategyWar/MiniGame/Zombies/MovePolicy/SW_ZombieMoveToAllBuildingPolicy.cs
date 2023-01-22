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
            _targetCell = cells[Random.Range(0, count - 1)];
            return true;
        }

        return false;
    }

    public override bool IsChangeObject() 
    { 
        return false; 
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

        if (IsRectsTouched(zombiePosition, zombieScale, cellPosition, cellScale))
        {
            return true;
        }

        return false;
    }

    public override Transform GetObject() 
    { 
        return _targetCell != null ? _targetCell.Behaviour.transform : null; 
    }

    private bool IsPointsTouched(Vector3 centerPoint, Vector3 objectPoint, Vector3 objectScale)
    {
        Vector2 objectTopLeft = new Vector2(objectPoint.x - objectScale.x / 2, objectPoint.y + objectScale.y / 2);
        Vector2 objectTopRight = new Vector2(objectTopLeft.x + objectScale.x, objectTopLeft.y);
        Vector2 objectDownLeft = new Vector2(objectTopLeft.x, objectTopLeft.y - objectScale.y);

        if (centerPoint.x >= objectTopLeft.x 
            && centerPoint.y <= objectTopLeft.y 
            && centerPoint.x <= objectTopRight.x 
            && centerPoint.y >= objectDownLeft.y)
        {
            return true;
        }

        return false;
    }

    private bool IsRectsTouched(Vector3 obj1Position, Vector3 obj1Scale, Vector3 obj2Position, Vector3 obj2Scale)
    {
        return IsPointsTouched(GetTopLeftPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetTopRightPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetDownLeftPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetDownRightPosition(obj1Position, obj1Scale), obj2Position, obj2Scale);
    }

    private Vector2 GetTopLeftPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        return new Vector2(objectPoint.x - objectScale.x / 2, objectPoint.y + objectScale.y / 2);
    }

    private Vector2 GetTopRightPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopLeft = GetTopLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopLeft.x + objectScale.x, objectTopLeft.y);
    }

    private Vector2 GetDownLeftPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopLeft = GetTopLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopLeft.x, objectTopLeft.y - objectScale.y);
    }

    private Vector2 GetDownRightPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopRight = GetTopRightPosition(objectPoint, objectScale);
        var objectDownLeft = GetDownLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopRight.x, objectDownLeft.y);
    }
}
