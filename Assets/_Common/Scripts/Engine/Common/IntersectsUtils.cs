using UnityEngine;

public class IntersectsUtils
{
    public static bool IsPointsTouched(Vector3 centerPoint, Vector3 objectPoint, Vector3 objectScale)
    {
        Vector2 objectTopLeft = new Vector2(objectPoint.x - objectScale.x / 2, objectPoint.y + objectScale.y / 2);
        Vector2 objectTopRight = new Vector2(objectTopLeft.x + objectScale.x, objectTopLeft.y);
        Vector2 objectDownLeft = new Vector2(objectTopLeft.x, objectTopLeft.y - objectScale.y);

        if (centerPoint.x >= objectTopLeft.x
            && centerPoint.y <= objectTopLeft.y
            && centerPoint.x <= objectTopRight.x
            && centerPoint.y >= objectDownLeft.y)
        {
            return true;
        }

        return false;
    }

    public static bool IsRectsTouched(Vector3 obj1Position, Vector3 obj1Scale, Vector3 obj2Position, Vector3 obj2Scale)
    {
        return IsPointsTouched(GetTopLeftPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetTopRightPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetDownLeftPosition(obj1Position, obj1Scale), obj2Position, obj2Scale)
            || IsPointsTouched(GetDownRightPosition(obj1Position, obj1Scale), obj2Position, obj2Scale);
    }

    public static Vector2 GetTopLeftPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        return new Vector2(objectPoint.x - objectScale.x / 2, objectPoint.y + objectScale.y / 2);
    }

    public static Vector2 GetTopRightPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopLeft = GetTopLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopLeft.x + objectScale.x, objectTopLeft.y);
    }

    public static Vector2 GetDownLeftPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopLeft = GetTopLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopLeft.x, objectTopLeft.y - objectScale.y);
    }

    public static Vector2 GetDownRightPosition(Vector3 objectPoint, Vector3 objectScale)
    {
        var objectTopRight = GetTopRightPosition(objectPoint, objectScale);
        var objectDownLeft = GetDownLeftPosition(objectPoint, objectScale);
        return new Vector2(objectTopRight.x, objectDownLeft.y);
    }
}
