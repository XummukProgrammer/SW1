using UnityEngine;

public class ResourceHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _value;

    public void SetValue(int value)
    {
        _value.text = value.ToString();
    }
}
