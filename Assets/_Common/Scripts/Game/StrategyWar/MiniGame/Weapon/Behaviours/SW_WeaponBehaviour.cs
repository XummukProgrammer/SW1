using UnityEngine;

public class SW_WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _muzzle;

    public Transform Muzzle => _muzzle;
}
