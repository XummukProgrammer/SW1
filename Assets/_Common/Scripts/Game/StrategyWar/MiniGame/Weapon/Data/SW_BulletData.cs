using UnityEngine;

[System.Serializable]
public class SW_BulletData
{
    [SerializeField] private string _name;
    [SerializeField] private SW_BulletBehaviour _prefab;
    [SerializeField] private float _speed;

    public string Name => _name;
    public SW_BulletBehaviour Prefab => _prefab;
    public float Speed => _speed;
}
