using UnityEngine;

[System.Serializable]
public class SW_WeaponData
{
    [SerializeField] private string _name;
    [SerializeField] private SW_WeaponBehaviour _prefab;
    [SerializeField] private float _reloadMaxTime;
    [SerializeField] private string _bulletName;

    public string Name => _name;
    public SW_WeaponBehaviour Prefab => _prefab;
    public float ReloadMaxTime => _reloadMaxTime;
    public string BulletName => _bulletName;
}
