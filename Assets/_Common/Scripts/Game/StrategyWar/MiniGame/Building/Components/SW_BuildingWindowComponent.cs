using UnityEngine;

public class SW_BuildingWindowComponent : WindowComponent<SW_BuildingWindowController, SW_MiniGame>
{
    [SerializeField] private SW_BuildingItemData[] _items;

    protected override void OnCreate()
    {
        base.OnCreate();

        SW_BuildingWindowBehaviour behaviour = null;
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
