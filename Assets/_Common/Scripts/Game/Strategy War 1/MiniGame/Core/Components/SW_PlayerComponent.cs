using UnityEngine;

public class SW_PlayerComponent : GameComponent<SW_MiniGame>
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClicked();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightClicked();
        }
    }

    private void OnMouseLeftClicked()
    {
        TryClickToCell();
    }

    private void OnMouseRightClicked()
    {
        TryShowContextMenu();
    }

    private void TryClickToCell()
    {
        var cell = GetCellInMouseArea();

        if (cell != null)
        {
            MiniGame.OnPlayerCellClicked(cell);
        }
    }

    private void TryShowContextMenu()
    {
        var cell = GetCellInMouseArea();

        if (cell != null)
        {
            MiniGame.OnCellShowContextMenu(cell);
        }
    }

    private Cell GetCellInMouseArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(MiniGame.EntryPoint.GetMousePosition(), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out CellBehaviour cellBehaviour))
            {
                return cellBehaviour.Cell;
            }
        }

        return null;
    }
}
