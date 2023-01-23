using UnityEngine;

[System.Serializable]
public class SW_ZombieWaveData
{
    [SerializeField] private string _waveId;
    [SerializeField] private SW_ZombieWaveSpawnData[] _spawns;

    public string WaveId => _waveId;
    public SW_ZombieWaveSpawnData[] Spawns => _spawns;
}
