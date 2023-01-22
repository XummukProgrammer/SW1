public class SW_ZombieAttackBuildingPolicy : SW_ZombieAttackPolicy
{
    private bool _isTargetRemoved = false;

    public override bool CanAttack() 
    { 
        return true; 
    }

    public override void Attack() 
    {
        _isTargetRemoved = false;

        var movePolicy = Zombie.MovePolicy;
        if (movePolicy == null)
        {
            return;
        }

        var target = movePolicy.GetObject();
        if (target == null)
        {
            return;
        }

        if (target.TryGetComponent(out SW_BuildingCellBehaviour behaviour))
        {
            if (behaviour.Cell is SW_BuildingCell)
            {
                Zombie.MiniGame.FieldComponent.Field.RemoveCell(behaviour.Cell);
                _isTargetRemoved = true;
            }
        }
    }

    public override bool IsTargetRemoved() 
    { 
        return _isTargetRemoved; 
    }
}
