using UnityEngine;

public class SW_BuildingWindowItemController
{
    private Transform _container;
    private SW_BuildingWindowItemBehaviour _itemPrefab;
    private SW_BuildingItemData _data;

    private SW_BuildingWindowItemBehaviour _behaviour;

    public void Init(Transform container, SW_BuildingWindowItemBehaviour itemPrefab, SW_BuildingItemData data)
    {
        _container = container;
        _itemPrefab = itemPrefab;
        _data = data;

        _behaviour = GameObject.Instantiate(_itemPrefab, _container);
        _behaviour.Init(_data);
    }

    public void Deinit()
    {
    }
}
