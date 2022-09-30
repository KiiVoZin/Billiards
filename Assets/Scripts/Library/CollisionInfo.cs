using System.Linq.Expressions;

public class CollisionInfo
{
    public float Depth;
    public Vec2 Normal;
    public Vec2 Start;
    public Vec2 End;
    public CollisionInfo()
    {
        Depth = 0;
        Normal = new Vec2(0, 0);
        Start = new Vec2(0, 0);
        End = new Vec2(0, 0);
    }

    public void ChangeDir()
    {
        Normal = this.Normal.Scale(-1);
        (this.End, this.Start) = (this.Start, this.End);
    }

    public void SetInfo(float depth, Vec2 normal, Vec2 start)
    {
        Depth = depth;
        Normal = normal;
        Start = start;
        End = start.Add(normal.Scale(depth));
    }
}
