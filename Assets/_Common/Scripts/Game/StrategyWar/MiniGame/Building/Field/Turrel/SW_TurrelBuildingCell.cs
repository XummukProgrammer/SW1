public class SW_TurrelBuildingCell : SW_BuildingCell
{
    private SW_TurrelBuildingVisionPolicy _visionPolicy;
    private SW_TurrelBuildingAttackPolicy _attackPolicy;
    private string _weaponName;

    public SW_TurrelBuildingVisionPolicy VisionPolicy => _visionPolicy;
    public SW_TurrelBuildingAttackPolicy AttackPolicy => _attackPolicy;
    public string WeaponName => _weaponName;

    public void SetWeaponName(string weaponName)
    {
        _weaponName = weaponName;
    }

    public void SetPolicy(SW_TurrelBuildingVisionPolicy visionPolicy, SW_TurrelBuildingAttackPolicy attackPolicy)
    {
        _visionPolicy = visionPolicy;
        _attackPolicy = attackPolicy;
    }

    public override void OnStart()
    {
        base.OnStart();

        _visionPolicy.Init(this);
        _attackPolicy.Init(this);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _attackPolicy.OnUpdate();

        VisionUpdate();
    }

    private void VisionUpdate()
    {
        if (!_visionPolicy.IsObjectValid())
        {
            OnFindObject();
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
                OnFindObject();
            }
        }
    }

    public void OnFindObject()
    {
        _visionPolicy.FindObject();
        _attackPolicy.SetTarget(_visionPolicy.IsObjectValid() ? _visionPolicy.GetObject() : null);
    }
}
