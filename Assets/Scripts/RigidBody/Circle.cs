using UnityEngine.Scripting.APIUpdating;

public class Circle: RigidShape
{
    public float Radius;
    public Circle(Vec2 center, float radius, float mass, float friction, float restitution) : base(center, "Circle", radius, mass, friction, restitution)
    {
        Radius = radius;
        UpdateInertia();
    }

    public override RigidShape Move(Vec2 vec)
    {
        this.Center = this.Center.Add(vec);
        return this;
    }

    public Circle Rotate(float angle)
    {
        this.Angle = angle;
        return this;
    }

    public override void UpdateInertia()
    {
        if(this.InvMass == 0)
        {
            this.Inertia = 0;
        }
        else
        {
            this.Inertia = (1 / this.InvMass) * (this.Radius * this.Radius) / 12;
        }
    }
}
