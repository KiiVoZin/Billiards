using System;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Circle_Collision : MonoBehaviour
{
    public static bool CollisionTest(RigidShape thisShape,RigidShape otherShape, out CollisionInfo collisionInfo)
    {
        collisionInfo = new CollisionInfo();
        var status = false;
        if(otherShape.Type == "Circle")
        {
            status = CollidedCircCirc((Circle)thisShape, (Circle)otherShape, out collisionInfo);
        }
        else
        {
            status = false;
        }
        return status;
    }

    public static bool CollidedCircCirc(Circle c1, Circle c2, out CollisionInfo collisionInfo)
    {
        collisionInfo = new CollisionInfo();
        var vFrom1to2 = c2.Center.Subtract(c1.Center);
        var rSum = c1.Radius + c2.Radius;
        var dist = vFrom1to2.Length();
        if(dist > Math.Sqrt(rSum * rSum))
        {
            return false;
        }
        if (dist != 0)
        {
            var normalFrom21to1 = vFrom1to2.Scale(-1).Normalize();
            var radiusC2 = normalFrom21to1.Scale(c2.Radius);
            collisionInfo.SetInfo(rSum - dist, vFrom1to2.Normalize(), c2.Center.Add(radiusC2));
        }
        else
        {
            if(c1.Radius > c2.Radius)
            {
                collisionInfo.SetInfo(rSum, new Vec2(0, -1), c1.Center.Add(new Vec2(0, c1.Radius)));
            }
            else
            {
                collisionInfo.SetInfo(rSum, new Vec2(0, -1), c2.Center.Add(new Vec2(0, c2.Radius)));
            }
        }
        return false;
    }
}
