using System.Collections.Generic;
using UnityEngine;

public class SW_BuildingSelectWindowBehaviour : WindowBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private SW_BuildingSelectWindowItemBehaviour _itemPrefab;

    private SW_MiniGame _miniGame;
    private List<SW_BuildingSelectWindowItemController> _controllers = new List<SW_BuildingSelectWindowItemController>();

    public void Init(SW_MiniGame miniGame)
    {
        _miniGame = miniGame;
    }

    public void AddItem(SW_BuildingItemData data)
    {
        var controller = new SW_BuildingSelectWindowItemController();
        controller.Init(_miniGame, _content, _itemPrefab, data);
        _controllers.Add(controller);
    }
}
