using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Physics
{
    static bool positionalCorrectionFlag = true;
    static int relaxationCount = 15;
    static float posCorrectionRate = 0.8f;
    public Physics() { }

    public static CollisionInfo Collision(List<RigidShape> rigidShapes)
    {
        CollisionInfo collisionInfo = new CollisionInfo();
        for (int k = 0; k < relaxationCount; k++)
        {
            for (int i = 0; i < rigidShapes.Count; i++)
            {
                for (int j = i + 1; j < rigidShapes.Count; j++)
                {
                    if (rigidShapes[i].BoundTest(rigidShapes[j]))
                    {
                        if (Circle_Collision.CollisionTest(rigidShapes[i], rigidShapes[j], out collisionInfo))
                        {
                            if (collisionInfo.Normal.Dot(rigidShapes[j].Center.Subtract(rigidShapes[i].Center)) < 0)
                            {
                                collisionInfo.ChangeDir();
                            }
                            ResolveCollision(rigidShapes[i], rigidShapes[j], collisionInfo);
                        }
                    }
                }
            }
        }
        return collisionInfo;
    }

    public static void PositionalCorrection(RigidShape shape1, RigidShape shape2, CollisionInfo collisionInfo)
    {
        var shape1InvMass = shape1.InvMass;
        var shape2InvMass = shape2.InvMass;

        var num = collisionInfo.Depth / (shape1InvMass + shape2InvMass) * posCorrectionRate;
        var correctionAmount = collisionInfo.Normal.Scale(num);

        shape1.Move(correctionAmount.Scale(-shape1InvMass));
        shape2.Move(correctionAmount.Scale(shape2InvMass));
    }

    public static void ResolveCollision(RigidShape shape1, RigidShape shape2, CollisionInfo collisionInfo)
    {
        if ((shape1.InvMass == 0) && (shape2.InvMass == 0)) return;
        if (Physics.positionalCorrectionFlag)
        {
            PositionalCorrection(shape1, shape2, collisionInfo);
        }

        var n = collisionInfo.Normal;
        var v1 = shape1.Velocity;
        var v2 = shape2.Velocity;
        var relativeVelocity = v2.Subtract(v1);

        var rVelocityInNormal = relativeVelocity.Dot(n);

        if (rVelocityInNormal > 0) return;

        var newRestitution = Mathf.Min(shape1.Restitution, shape2.Restitution);
        var newFriction = Mathf.Min(shape1.Friction, shape2.Friction);
        var jN = -(1 + newRestitution) * rVelocityInNormal;
        jN = jN / (shape1.InvMass + shape2.InvMass);

        var impulse = n.Scale(jN);
        shape1.Velocity = shape1.Velocity.Subtract(impulse.Scale(shape1.InvMass));
        shape2.Velocity = shape2.Velocity.Add(impulse.Scale(shape2.InvMass));

        var tangent = relativeVelocity.Subtract(n.Scale(relativeVelocity.Dot(n)));
        tangent = tangent.Normalize().Scale(-1);

        var jT = -(1 + newRestitution) * relativeVelocity.Dot(tangent) * newFriction;
        jT = jT / (shape1.InvMass + shape2.InvMass);

        if (jT > jN) jT = jN;
        impulse = tangent.Scale(jT);

        shape1.Velocity = shape1.Velocity.Subtract(impulse.Scale(shape1.InvMass));
        shape2.Velocity = shape2.Velocity.Add(impulse.Scale(shape2.InvMass));
    }
}
