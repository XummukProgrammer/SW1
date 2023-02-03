using UnityEngine;

public class SW_ZombieBehaviour : MonoBehaviour
{
    private SW_Zombie _zombie;

    public SW_Zombie Zombie => _zombie;

    public void Init(SW_Zombie zombie)
    {
        _zombie = zombie;
    }
}
