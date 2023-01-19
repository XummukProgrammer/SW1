using UnityEngine;

public class SW_BuildingContextMenuComponent : TooltipComponent<SW_MiniGame>
{
    private Cell _targetCell;

    public void SetTargetCell(Cell targetCell) 
    { 
        _targetCell = targetCell; 
    }

    protected override private Transform GetTarget() { return _targetCell.Behaviour.transform; }

    protected override void OnCreate()
    {
        base.OnCreate();

        if (Tooltip.Behaviour.TryGetComponent(out SW_BuildingContextMenuBehaviour behaviour))
        {
            behaviour.RemoveButtonClickedDelegate = OnRemoveButtonClicked;
        }
    }

    protected override void OnRemove()
    {
        base.OnRemove();

        if (Tooltip.Behaviour.TryGetComponent(out SW_BuildingContextMenuBehaviour behaviour))
        {
            behaviour.RemoveButtonClickedDelegate -= OnRemoveButtonClicked;
        }
    }

    private void OnRemoveButtonClicked()
    {
        MiniGame.FieldComponent.Field.RemoveCell(_targetCell);
        _targetCell = null;
    }
}
