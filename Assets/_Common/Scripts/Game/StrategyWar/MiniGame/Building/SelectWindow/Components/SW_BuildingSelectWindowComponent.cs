using UnityEngine;

public class SW_BuildingSelectWindowComponent : WindowComponent<SW_BuildingSelectWindowController, SW_MiniGame>
{
    [SerializeField] private SW_BuildingItemData[] _items;

    protected override void OnCreate()
    {
        base.OnCreate();

        SW_BuildingSelectWindowBehaviour behaviour = null;
        if (!Controller.Behaviour.TryGetComponent(out behaviour))
        {
            return;
        }

        behaviour.Init(MiniGame);

        foreach (var item in _items)
        {
            behaviour.AddItem(item);
        }
    }
}
