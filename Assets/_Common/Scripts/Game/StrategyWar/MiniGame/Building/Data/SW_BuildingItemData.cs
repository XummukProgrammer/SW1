using UnityEngine;

[System.Serializable]
public class SW_BuildingItemData
{
    [SerializeField] private string _id;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;

    public string Id => _id;
    public int Price => _price;
    public Sprite Sprite => _sprite;
}
