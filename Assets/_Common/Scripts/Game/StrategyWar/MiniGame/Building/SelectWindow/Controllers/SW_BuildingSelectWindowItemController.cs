using UnityEngine;

public class SW_BuildingSelectWindowItemController
{
    private SW_MiniGame _miniGame;

    private Transform _container;
    private SW_BuildingSelectWindowItemBehaviour _itemPrefab;
    private SW_BuildingItemData _data;

    private SW_BuildingSelectWindowItemBehaviour _behaviour;

    public void Init(SW_MiniGame miniGame, Transform container, SW_BuildingSelectWindowItemBehaviour itemPrefab, SW_BuildingItemData data)
    {
        _miniGame = miniGame;
        _container = container;
        _itemPrefab = itemPrefab;
        _data = data;

        _behaviour = GameObject.Instantiate(_itemPrefab, _container);
        _behaviour.Init(_data);
        _behaviour.Bought += OnBought;
    }

    public void Deinit()
    {
        _behaviour.Bought -= OnBought;
    }

    private void OnBought()
    {
        Debug.Log($"Bought {_data.Id}");
        _miniGame.BuildingSelectWindowComponent.Controller.Close();
    }
}
