using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    private Cell _cell;

    public Cell Cell => _cell;

    public void Init(Cell cell, string name, float x, float y, float width, float height, Vector2 startPosition)
    {
        _cell = cell;

        gameObject.name = name;

        float targetX = startPosition.x + x * width + width / 2;
        float targetY = startPosition.y - y * height - height / 2;
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
