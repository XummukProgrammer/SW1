using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    [SerializeField] private Vector2 _size;
    [SerializeField] private SW_Settings _settings;
    [SerializeField] private bool _isDrawGizmos = true;

    private Cell _cell;

    public Cell Cell => _cell;
    public Vector2 Size => _size;

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
        if (!_isDrawGizmos || !_settings)
        {
            return;
        }

        Gizmos.color = Color.yellow;

        float x = transform.position.x - transform.localScale.x / 2;
        float y = transform.position.y + transform.localScale.y / 2;
        float width = _settings.CellSize.x * _size.x;
        float height = _settings.CellSize.y * _size.y;

        Gizmos.DrawLine(new Vector3(x, y, transform.position.z), new Vector3(x + width, y, transform.position.z));
        Gizmos.DrawLine(new Vector3(x, y, transform.position.z), new Vector3(x, y - height, transform.position.z));
        Gizmos.DrawLine(new Vector3(x, y - height, transform.position.z), new Vector3(x + width, y - height, transform.position.z));
        Gizmos.DrawLine(new Vector3(x + width, y, transform.position.z), new Vector3(x + width, y - height, transform.position.z));
    }
}
