public class SW_BuildingContextMenuBehaviour : TooltipBehaviour
{
    public delegate void DefaultDelegate();
    public DefaultDelegate RemoveButtonClickedDelegate;
    public DefaultDelegate CloseButtonClickedDelegate;

    public void OnRemoveButtonClicked()
    {
        RemoveButtonClickedDelegate?.Invoke();
    }

    public void OnCloseButtonClicked()
    {
        CloseButtonClickedDelegate?.Invoke();
    }
}
