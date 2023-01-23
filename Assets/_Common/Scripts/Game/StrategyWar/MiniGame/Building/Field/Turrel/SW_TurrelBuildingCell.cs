public class SW_TurrelBuildingCell : SW_BuildingCell
{
    private SW_TurrelBuildingVisionPolicy _visionPolicy;
    private SW_TurrelBuildingAttackPolicy _attackPolicy;

    public SW_TurrelBuildingVisionPolicy VisionPolicy => _visionPolicy;
    public SW_TurrelBuildingAttackPolicy AttackPolicy => _attackPolicy;

    public void SetPolicy(SW_TurrelBuildingVisionPolicy visionPolicy, SW_TurrelBuildingAttackPolicy attackPolicy)
    {
        _visionPolicy = visionPolicy;
        _attackPolicy = attackPolicy;

        _visionPolicy.Init(this);
        _attackPolicy.Init(this);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        VisionUpdate();
    }

    private void VisionUpdate()
    {
        if (!_visionPolicy.IsObjectValid())
        {
            _visionPolicy.FindObject();
        }
        else
        {
            AttackUpdate();
        }
    }

    private void AttackUpdate()
    {
        if (_attackPolicy.CanAttack())
        {
            _attackPolicy.Attack();

            if (_attackPolicy.IsTargetRemove())
            {
                _visionPolicy.FindObject();
            }
        }
    }
}
