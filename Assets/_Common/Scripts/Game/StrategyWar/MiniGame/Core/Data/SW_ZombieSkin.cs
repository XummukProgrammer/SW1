using UnityEngine;

[System.Serializable]
public class SW_ZombieSkin
{
    [SerializeField] private string _id;
    [SerializeField] private SW_ZombieBehaviour _prefab;

    public string Id => _id;
    public SW_ZombieBehaviour Prefab => _prefab;
}
