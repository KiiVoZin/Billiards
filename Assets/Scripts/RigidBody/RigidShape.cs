using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
[Serializable]
public abstract class RigidShape
{
    public Vec2 Center;
    public float Angle;
    public float BoundRadius;
    public Vec2 Velocity;
    public Vec2 Acceleration;
    public float Friction;
    public float Restitution;

    float mass;
    public float Mass
    {
        set { mass = value;
            InvMass = 1 / mass;
        }
        
        get { return mass; }
    }
    public float InvMass;
    public float Inertia;
    RigidShape(Vec2 center, float boundRadius, float mass, float friction, float restitution)
    {
        Center = center;
        Angle = 0;
        BoundRadius = boundRadius;
        Velocity = new Vec2(0, 0);
        Acceleration = Core.Gravity;
        Mass = mass;
        Friction = friction;
        Restitution = restitution;
        InvMass = 1 / Mass;
        Inertia = 0;
    }

    public static Circle CreateCircleRigid(Vec2 center, float boundRadius, float mass, float friction, float restitution)
    {
        return new Circle(center, boundRadius, mass, friction, restitution);
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

    public RigidShape Move(Vec2 vec2)
    {
        this.Center = this.Center.Add(vec2);
        return this;
    }
    public virtual void UpdateInertia() { }
}
