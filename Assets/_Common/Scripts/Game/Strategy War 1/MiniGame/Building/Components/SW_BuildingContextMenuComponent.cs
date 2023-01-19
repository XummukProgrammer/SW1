using UnityEngine;

public class SW_BuildingContextMenuComponent : TooltipComponent<SW_MiniGame>
{
    private Cell _targetCell;
    private bool _isCreated = false;

    public bool IsCreated => _isCreated;

    public void SetTargetCell(Cell targetCell) 
    { 
        _targetCell = targetCell; 
    }

    protected override private Transform GetTarget() { return _targetCell.Behaviour.transform; }

    protected override void OnCreate()
    {
        base.OnCreate();

        _isCreated = true;

        if (Tooltip.Behaviour.TryGetComponent(out SW_BuildingContextMenuBehaviour behaviour))
        {
            behaviour.RemoveButtonClickedDelegate += OnRemoveButtonClicked;
            behaviour.CloseButtonClickedDelegate += OnCloseButtonClicked;
        }
    }

    protected override void OnRemove()
    {
        base.OnRemove();

        _isCreated = false;

        if (Tooltip.Behaviour.TryGetComponent(out SW_BuildingContextMenuBehaviour behaviour))
        {
            behaviour.RemoveButtonClickedDelegate -= OnRemoveButtonClicked;
            behaviour.CloseButtonClickedDelegate -= OnCloseButtonClicked;
        }
    }

    private void OnRemoveButtonClicked()
    {
        MiniGame.FieldComponent.Field.RemoveCell(_targetCell);
        _targetCell = null;

        OnCloseButtonClicked();
    }

    private void OnCloseButtonClicked()
    {
        Remove();
    }
}
