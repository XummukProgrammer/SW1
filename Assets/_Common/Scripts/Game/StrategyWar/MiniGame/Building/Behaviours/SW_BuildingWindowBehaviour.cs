using System.Collections.Generic;
using UnityEngine;

public class SW_BuildingWindowBehaviour : WindowBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private SW_BuildingWindowItemBehaviour _itemPrefab;

    private SW_MiniGame _miniGame;
    private List<SW_BuildingWindowItemController> _controllers = new List<SW_BuildingWindowItemController>();

    public void Init(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;
    }

    public void AddItem(SW_BuildingItemData data)
    {
        var controller = new SW_BuildingWindowItemController();
        controller.Init(_miniGame, _content, _itemPrefab, data);
        _controllers.Add(controller);
    }
}
