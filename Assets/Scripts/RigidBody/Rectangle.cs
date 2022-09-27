using System;
using Unity.VisualScripting;

public class Rectangle : RigidShape
{
    public float Width;
    public float Height;
    public Vec2[] Vertexes;
    public Vec2[] Normals;
    public Rectangle(Vec2 center, float width, float height) : base(center, "Rectangle")
    {
        Width = width;
        Height = height;
        Vertexes = new Vec2[4];
        Normals = new Vec2[4];

        ComputeVertexes();
        ComputeNormals();
    }

    public void ComputeVertexes()
    {
        Vertexes[0] = new Vec2(Center.x - Width / 2, Center.y - Height / 2);
        Vertexes[1] = new Vec2(Center.x + Width / 2, Center.y - Height / 2);
        Vertexes[2] = new Vec2(Center.x + Width / 2, Center.y + Height / 2);
        Vertexes[3] = new Vec2(Center.x - Width / 2, Center.y + Height / 2);
    }

    public void ComputeNormals()
    {
        Normals[0] = Vertexes[1].Subtract(Vertexes[2]).Normalize();
        Normals[1] = Vertexes[2].Subtract(Vertexes[3]).Normalize();
        Normals[2] = Vertexes[3].Subtract(Vertexes[0]).Normalize();
        Normals[3] = Vertexes[0].Subtract(Vertexes[1]).Normalize();
    }
}
