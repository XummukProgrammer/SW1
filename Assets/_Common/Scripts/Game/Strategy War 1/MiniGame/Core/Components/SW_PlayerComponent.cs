using UnityEngine;
using UnityEngine.UIElements;

public class SW_PlayerComponent : GameComponent<SW_MiniGame>
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClicked();
        }
    }

    private void OnMouseLeftClicked()
    {
        TryClickToCell();
    }

    private void TryClickToCell()
    {
        RaycastHit2D hit = Physics2D.Raycast(MiniGame.EntryPoint.GetMousePosition(), Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out CellBehaviour cellBehaviour))
            {
                MiniGame.OnPlayerCellClicked(cellBehaviour.Cell);
            }
        }
    }
}
