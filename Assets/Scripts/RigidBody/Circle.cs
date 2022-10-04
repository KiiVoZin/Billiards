using System;
using UnityEngine.Scripting.APIUpdating;

[Serializable]
public class Circle : RigidShape
{
    private float radius;
    public float Radius
    {
        get { return radius; }
        set
        {
            radius = value;
            BoundRadius = value;
        }
    }
    public Circle(Vec2 center, float radius, float mass, float friction, float restitution) : base(center, radius, mass, friction, restitution)
    {
        Radius = radius;
        UpdateInertia();
    }


    public Circle Rotate(float angle)
    {
        this.Angle = angle;
        return this;
    }

    public override void UpdateInertia()
    {
        if (this.InvMass == 0)
        {
            this.Inertia = 0;
        }
        else
        {
            this.Inertia = (1 / this.InvMass) * (this.Radius * this.Radius) / 12;
        }
    }
}