using UnityEngine;

[System.Serializable]
public class SW_CellSkin
{
    [SerializeField] private string _id;
    [SerializeField] private CellBehaviour _prefab;

    public string Id => _id;
    public CellBehaviour Prefab => _prefab;
}
