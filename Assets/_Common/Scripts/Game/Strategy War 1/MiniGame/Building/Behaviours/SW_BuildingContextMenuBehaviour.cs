public class SW_BuildingContextMenuBehaviour : TooltipBehaviour
{
    public delegate void DefaultDelegate();
    public DefaultDelegate RemoveButtonClickedDelegate;

    public void OnRemoveButtonClicked()
    {
        RemoveButtonClickedDelegate?.Invoke();
    }
}
