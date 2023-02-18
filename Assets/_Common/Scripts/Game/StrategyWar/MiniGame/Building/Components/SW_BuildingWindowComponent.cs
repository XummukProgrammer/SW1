using UnityEngine;

public class SW_BuildingWindowComponent : WindowComponent<SW_BuildingWindowController, SW_MiniGame>
{
    [SerializeField] private SW_BuildingItemData[] _items;

    protected override void OnCreate()
    {
        base.OnCreate();

        foreach (var item in _items)
        {
            if (Controller.Behaviour.TryGetComponent(out SW_BuildingWindowBehaviour behaviour))
            {
                behaviour.AddItem(item);
            }
        }
    }
}
