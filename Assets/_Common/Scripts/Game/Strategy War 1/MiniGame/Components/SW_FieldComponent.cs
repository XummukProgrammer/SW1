using UnityEngine;

public class SW_FieldComponent : GameComponent<SW_MiniGame>
{
    [SerializeField] private Vector2Int _cellSize;
    [SerializeField] private Vector2 _startPosition;

    private Field _field = new Field();

    protected override void OnInit()
    {
        base.OnInit();
        
        var container = FindObjectOfType<CellsContainerBehaviour>();
        if (container != null)
        {
            _field.Init(MiniGame.EntryPoint, container.transform, _cellSize.x, _cellSize.y, _startPosition);

            // Debug
            for (int y = 0; y < 5; ++y)
            {
                for (int x = 0; x < 5; ++x)
                {
                    _field.CreateAndAddCell<Cell>(MiniGame.SkinsComponent.GetCellSkin("Ground").Prefab, x, y);
                }
            }

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
}
