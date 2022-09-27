public class RigidShape
{
    public Vec2 Center;
    public float Angle;
    public string Type;
    public RigidShape(Vec2 center, string type)
    {
        Center = center;
        Angle = 0;
        Type = type;
    }
}
