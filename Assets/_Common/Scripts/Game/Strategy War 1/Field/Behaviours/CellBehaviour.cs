using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    public void Init(float x, float y, float width, float height, Vector2 startPosition)
    {
        float targetX = startPosition.x + x * width + width / 2;
        float targetY = startPosition.y - y * height - height / 2;
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
