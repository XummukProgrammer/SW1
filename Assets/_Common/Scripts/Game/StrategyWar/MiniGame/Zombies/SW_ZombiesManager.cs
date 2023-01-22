using System;
using System.Collections.Generic;
using UnityEngine;

public class SW_ZombiesManager
{
    private Transform _container;
    private List<SW_Zombie> _zombies = new List<SW_Zombie>();

    public void SetContainer(Transform container)
    {
        _container = container;
    }

    public T CreateZombie<T>(SW_MiniGame miniGame, SW_ZombieBehaviour prefab, int x, int y) where T : SW_Zombie
    {
        var zombie = Activator.CreateInstance<T>();
        zombie.SetMiniGame(miniGame);
        zombie.SetPrefab(prefab);
        AddZombie(zombie, x, y);
        return zombie;
    }
   
    public void AddZombie(SW_Zombie zombie, int x, int y)
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
}
