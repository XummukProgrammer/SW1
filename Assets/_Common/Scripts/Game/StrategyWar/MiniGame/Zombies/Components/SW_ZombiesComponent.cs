using UnityEngine;

public class SW_ZombiesComponent : GameComponent<SW_MiniGame>
{
    private SW_ZombiesManager _zombies = new SW_ZombiesManager();
    private Transform _container;

    public SW_ZombiesManager Zombies => _zombies;

    protected override void OnInit()
    {
        base.OnInit();

        _container = FindObjectOfType<SW_ZombiesContainerBehaviour>().transform;
        _zombies.SetContainer(_container);

        // Debug
        CreateZombie<SW_Zombie>("Zombie", 0, 0);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        _zombies.ClearZombies();
    }

    public override void OnUpdate()
    {
        _zombies.UpdateZombies();
    }

    public void CreateZombie<T>(string skinId, int x, int y) where T : SW_Zombie
    {
        var skin = MiniGame.SkinsComponent.GetZombieSkin(skinId);
        if (skin == null)
        {
            Debug.Log("[SW] No found zombie skin: " + skinId);
            return;
        }

        if (skin.Prefab == null)
        {
            Debug.Log("[SW] No found prefab for zombie skin: " + skinId);
            return;
        }

        _zombies.CreateZombie<T>(MiniGame, skin.Prefab, x, y);
    }

    public void RemoveZombie(SW_Zombie zombie)
    {
        _zombies.RemoveZombie(zombie);
    }
}
