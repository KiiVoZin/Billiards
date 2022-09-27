using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionScript
{
    public static bool IsColliding(GameObject obj1, GameObject obj2)
    {
        Vector3 obj1Scale = obj1.transform.localScale;
        Vector3 obj2Scale = obj2.transform.localScale;
        float obj1Radius = Mathf.Sqrt(obj1Scale.x * obj1Scale.x + obj1Scale.y * obj1Scale.y)/2;
        float obj2Radius = Mathf.Sqrt(obj2Scale.x * obj2Scale.x + obj2Scale.y * obj2Scale.y)/2;
        if (Vector2.Distance(obj1.transform.position, obj2.transform.position) < obj1Radius + obj2Radius) return true;
        return false;
    }
}
