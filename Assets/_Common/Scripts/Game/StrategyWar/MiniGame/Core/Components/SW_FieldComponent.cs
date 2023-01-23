using UnityEngine;

public class SW_FieldComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private SW_Settings _settings;

    private Field _field = new Field();

    public Field Field => _field;

    protected override void OnInit()
    {
        base.OnInit();
        
        var container = FindObjectOfType<CellsContainerBehaviour>();
        if (container != null)
        {
            _field.Init(MiniGame.EntryPoint, container.transform, _settings.CellSize.x, _settings.CellSize.y, _settings.StartPosition);

            // Debug
            for (int y = 0; y < 20; ++y)
            {
                for (int x = 0; x < 20; ++x)
                {
                    CreateCell<Cell>("Ground", x, y, 0, true);
                }
            }

            CreateCell<Cell>("Player", 1, 1, 0, true);

            CreateCell<SW_PeopleBuildingCell>("Building", 3, 3, 0, true);
            CreateCell<SW_PeopleBuildingCell>("Building", 4, 3, 0, true);
            CreateCell<SW_PeopleBuildingCell>("Building", 5, 3, 0, true);
            CreateCell<SW_PeopleBuildingCell>("Building", 6, 3, 0, true);

            var turrelCell = CreateCell<SW_TurrelBuildingCell>("Turrel", 5, 5, 0, true);
            turrelCell.SetPolicy(new SW_TurrelBuildingZombieVisionPolicy(), new SW_TurrelBuildingAttackPolicy());

            Debug.Log("[SW] Success init field!");
        }
        else
        {
            Debug.Log("[SW] No found CellsContainerBehaviour!");
        }
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        _field.Deinit();
    }

    public override void OnStart()
    {
        base.OnStart();

        _field.OnStart();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _field.OnUpdate();
    }

    public T CreateCell<T>(string skinId, int x, int y, int layer, bool isForce) where T : Cell
    {
        var skin = MiniGame.SkinsComponent.GetCellSkin(skinId);
        if (skin == null)
        {
            Debug.Log($"[SW] No found skin: {skinId}");
            return null;
        }

        if (skin.Prefab == null)
        {
            Debug.Log($"[SW] No found prefab for skin: {skinId}");
            return null;
        }

        return _field.CreateAndAddCell<T>(skin.Prefab, x, y, layer, isForce);
    }
}
