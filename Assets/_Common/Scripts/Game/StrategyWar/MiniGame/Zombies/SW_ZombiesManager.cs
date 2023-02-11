using System;
using System.Collections.Generic;
using UnityEngine;

public class SW_ZombiesManager
{
    private SW_MiniGame _miniGame;
    private Transform _container;
    private SW_ZombieWavesData _waves;
    private SW_ZombiesData _zombiesData;
    private List<SW_Zombie> _zombies = new List<SW_Zombie>();

    public List<SW_Zombie> Zombies => _zombies;

    public void SetMiniGame(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;
    }

    public void SetContainer(Transform container)
    {
        _container = container;
    }

    public void SetWaves(SW_ZombieWavesData waves)
    {
        _waves = waves;
    }

    public void SetZombiesData(SW_ZombiesData zombiesData)
    {
        _zombiesData = zombiesData;
    }

    public T CreateZombie<T>(SW_MiniGame miniGame, string skinId, float x, float y, SW_ZombieMovePolicy movePolicy, SW_ZombieAttackPolicy attackPolicy) where T : SW_Zombie
    {
        var skin = _miniGame.SkinsComponent.GetZombieSkin(skinId);
        if (skin == null)
        {
            Debug.Log("[SW] No found zombie skin: " + skinId);
            return null;
        }

        if (skin.Prefab == null)
        {
            Debug.Log("[SW] No found prefab for zombie skin: " + skinId);
            return null;
        }

        var zombie = Activator.CreateInstance<T>();
        zombie.SetMiniGame(miniGame);
        zombie.SetPrefab(skin.Prefab);
        zombie.SetMovePolicy(movePolicy);
        zombie.SetAttackPolicy(attackPolicy);
        AddZombie(zombie, x, y);
        return zombie;
    }
   
    public void AddZombie(SW_Zombie zombie, float x, float y)
    {
        _zombies.Add(zombie);
        zombie.SetContainer(_container);
        zombie.Init();
        zombie.Create();
        zombie.SetPosition(x, y);
    }

    public void RemoveZombie(SW_Zombie zombie)
    {
        _zombies.Remove(zombie);
        zombie.Deinit();
        zombie.Remove();
    }

    public void ClearZombies()
    {
        foreach (var zombie in _zombies)
        {
            zombie.Deinit();
            zombie.Remove();
        }

        _zombies.Clear();
    }

    public void UpdateZombies()
    {
        foreach (var zombie in _zombies)
        {
            zombie.Update();
        }
    }

    public void StartWave(string waveId)
    {
        var wave = _waves.GetWaveById(waveId);
        if (wave == null)
        {
            Debug.Log("[SW] No found wave: " + waveId);
            return;
        }

        var spawns = wave.Spawns;
        foreach (var spawn in spawns)
        {
            var zombieId = spawn.ZombieId;
            var zombiesCount = spawn.ZombiesCount;
            var zombiesSpawnRadius = spawn.ZombiesSpawnRadius;
            var zombiesSpawnPosition = spawn.ZombiesSpawnPosition;

            for (int i = 0; i < zombiesCount; ++i)
            {
                var zombieData = _zombiesData.GetZombieById(zombieId);
                if (zombieData != null)
                {
                    var zombiePosition = new Vector2(UnityEngine.Random.Range(-zombiesSpawnRadius, zombiesSpawnRadius) + zombiesSpawnPosition.x,
                        UnityEngine.Random.Range(-zombiesSpawnRadius, zombiesSpawnRadius) + zombiesSpawnPosition.y);

                    var movePolicy = CreateMovePolicy(zombieData.MovePolicyData);
                    var attackPolicy = CreateAttackPolicy(zombieData.AttackPolicyData);

                    CreateZombie<SW_Zombie>(_miniGame, zombieData.SkinId, zombiePosition.x, zombiePosition.y, movePolicy, attackPolicy);
                }
                else
                {
                    Debug.Log("[SW] No found zombie data id: " + zombieId);
                }
            }
        }
    }

    private SW_ZombieMovePolicy CreateMovePolicy(SW_ZombieMovePolicyData movePolicyData)
    {
        switch (movePolicyData)
        {
            case SW_ZombieMovePolicyData.ToAllBuilding:
                return new SW_ZombieMoveToAllBuildingPolicy();
            default:
                break;
        }

        return null;
    }

    private SW_ZombieAttackPolicy CreateAttackPolicy(SW_ZombieAttackPolicyData attackPolicyData)
    {
        switch (attackPolicyData)
        {
            case SW_ZombieAttackPolicyData.Building:
                return new SW_ZombieAttackBuildingPolicy();
            default:
                break;
        }

        return null;
    }

    public List<SW_Zombie> GetZombiesWithDistance(Vector3 position, float maxDistance)
    {
        List<SW_Zombie> zombies = new List<SW_Zombie>();

        foreach (var zombie in _zombies)
        {
            if (Vector3.Distance(position, zombie.Behaviour.transform.position) <= maxDistance)
            {
                zombies.Add(zombie);
            }
        }

        return zombies;
    }
}
