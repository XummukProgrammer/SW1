using UnityEngine;

public class CellBehaviour : MonoBehaviour
{
    public void Init(float x, float y, float width, float height, Vector2 startPosition)
    {
        float targetX = startPosition.x + x * width;
        float targetY = startPosition.y + y * height;
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
