using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Vec2
{
    public float x;
    public float y;
    public Vec2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public float Length()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public Vec2 Add(Vec2 vec)
    {
        return new Vec2(x + vec.x, y + vec.y);
    }

    public Vec2 Subtract(Vec2 vec)
    {
        return new Vec2(x - vec.x, y - vec.y);
    }

    public Vec2 Scale(float n)
    {
        return new Vec2(x * n, y * n);
    }

    public float Dot(Vec2 vec)
    {
        return (x * vec.x + y * vec.y);
    }
    public float Coss(Vec2 vec)
    {
        return (x * vec.y - y * vec.x);
    }

    public Vec2 Rotate(Vec2 center, float angle)
    {
        float[] r = new float[2];
        var x = this.x - center.x;
        var y = this.y - center.y;
        r[0] = x * Mathf.Cos(angle) - y * Mathf.Sin(angle);
        r[1] = x * Mathf.Sin(angle) + y * Mathf.Cos(angle);
        r[0] += center.x;
        r[1] += center.y;
        return new Vec2(r[0], r[1]);
    }

    public Vec2 Normalize()
    {
        var len = this.Length();
        if (len > 0)
        {
            len = 1 / len;
        }
        return new Vec2(this.x * len, this.y * len);
    }

    public float Distance(Vec2 vec)
    {
        var x = this.x - vec.x;
        var y = this.y - vec.y;
        return Mathf.Sqrt(x * x + y * y);
    }
}
