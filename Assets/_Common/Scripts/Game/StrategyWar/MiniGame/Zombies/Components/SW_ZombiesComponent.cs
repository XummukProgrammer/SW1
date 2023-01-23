using UnityEngine;

public class SW_ZombiesComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_ZombieWavesData _waves;
    [SerializeField] private SW_ZombiesData _zombiesData;

    private SW_ZombiesManager _zombies = new SW_ZombiesManager();
    private Transform _container;

    public SW_ZombiesManager Zombies => _zombies;

    protected override void OnInit()
    {
        base.OnInit();

        _container = FindObjectOfType<SW_ZombiesContainerBehaviour>().transform; // TODO: use locator! and other places.
        _zombies.SetMiniGame(MiniGame);
        _zombies.SetContainer(_container);
        _zombies.SetWaves(_waves);
        _zombies.SetZombiesData(_zombiesData);

        // Debug
        _zombies.StartWave("Wave1");
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
}
