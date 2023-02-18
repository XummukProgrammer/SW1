using UnityEngine;
using UnityEngine.UI;

public class SW_BuildingSelectWindowItemBehaviour : MonoBehaviour
{
    public event System.Action Bought;

    [SerializeField] private Image _image;
    [SerializeField] private TMPro.TMP_Text _price;

    public void Init(SW_BuildingItemData data)
    {
        _image.sprite = data.Sprite;
        _price.text = data.Price.ToString();
    }

    public void OnBought()
    {
        Bought?.Invoke();
    }
}
