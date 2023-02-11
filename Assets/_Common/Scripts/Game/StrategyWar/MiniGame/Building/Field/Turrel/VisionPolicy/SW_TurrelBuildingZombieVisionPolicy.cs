using UnityEngine;

public class SW_TurrelBuildingZombieVisionPolicy : SW_TurrelBuildingVisionPolicy
{
    private SW_Zombie _targetZombie;

    public override void FindObject() 
    {
        var zombies = TurrelCell.MiniGame.ZombiesComponent.Zombies.GetZombiesWithDistance(TurrelCell.Behaviour.transform.position, 5);
        var zombiesCount = zombies.Count;

        if (zombiesCount > 0)
        {
            _targetZombie = zombies[Random.Range(0, zombiesCount - 1)];
        }
        else
        {
            _targetZombie = null;
        }
    }

    public override Transform GetObject() 
    { 
        return _targetZombie != null ? _targetZombie.Behaviour.transform : null; 
    }

    public override bool IsObjectValid() 
    { 
        return _targetZombie != null && (Vector3.Distance(TurrelCell.Behaviour.transform.position, _targetZombie.Behaviour.transform.position) <= 5); 
    }
}
