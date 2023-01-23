using UnityEngine;

[System.Serializable]
public class SW_ZombieWavesData
{
    [SerializeField] private SW_ZombieWaveData[] _waves;

    public SW_ZombieWaveData GetWaveById(string waveId)
    {
        foreach (var wave in _waves)
        {
            if (wave.WaveId == waveId)
            {
                return wave;
            }
        }

        return null;
    }
}
