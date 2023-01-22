using UnityEngine;

[CreateAssetMenu(fileName = "SW_Settings", menuName = "SW/Create Settings")]
public class SW_Settings : ScriptableObject
{
    [SerializeField] private Vector2Int _cellSize;
    [SerializeField] private Vector2 _startPosition;

    public Vector2Int CellSize => _cellSize;
    public Vector2 StartPosition => _startPosition;
}
