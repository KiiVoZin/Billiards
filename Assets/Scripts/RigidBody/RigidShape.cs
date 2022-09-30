using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class RigidShape
{
    public Vec2 Center;
    public float Angle;
    public string Type;
    public float BoundRadius;
    public Vec2 Velocity;
    public Vec2 Acceleration;
    public float Friction;
    public float Restitution;
    public float Mass;
    public float InvMass;
    public float Inertia;
    public RigidShape(Vec2 center, string type, float boundRadius, float mass, float friction, float restitution)
    {
        Center = center;
        Angle = 0;
        Type = type;
        BoundRadius = boundRadius;
        Velocity = new Vec2(0, 0);
        Acceleration = Core.Gravity;
        Mass = mass;
        Friction = friction;
        Restitution = restitution;
        InvMass = 1 / Mass;
        Inertia = 0;
    }

    public bool BoundTest(RigidShape otherShape)
    {
        var vFrom1to2 = this.Center.Subtract(otherShape.Center);
        var rSum = this.BoundRadius + otherShape.BoundRadius;
        var dist = vFrom1to2.Length();
        if (dist > rSum)
        {
            return false;
        }
        return true;
    }

    public void UpdateMass(float delta)
    {
        Mass += delta;
        InvMass = 1 / Mass;
    }

    public virtual RigidShape Move(Vec2 vec2) { return this; }
    public virtual void UpdateInertia() { }
}
