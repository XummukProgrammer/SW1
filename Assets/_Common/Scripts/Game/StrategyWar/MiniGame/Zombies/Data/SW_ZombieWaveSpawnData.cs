using UnityEngine;

[System.Serializable]
public class SW_ZombieWaveSpawnData
{
    [SerializeField] private string _zombieId;
    [SerializeField] private int _zombiesCount = 1;
    [SerializeField] private float _zombiesSpawnRadius = 1;
    [SerializeField] private Vector2 _zombiesSpawnPosition;

    public string ZombieId => _zombieId;
    public int ZombiesCount => _zombiesCount;
    public float ZombiesSpawnRadius => _zombiesSpawnRadius;
    public Vector2 ZombiesSpawnPosition => _zombiesSpawnPosition;
}
