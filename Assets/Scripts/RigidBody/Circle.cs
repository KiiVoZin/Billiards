public class Circle: RigidShape
{
    public float Radius;
    public Circle(Vec2 center, float radius): base(center, "Circle")
    {
        Radius = radius;
    }
}
