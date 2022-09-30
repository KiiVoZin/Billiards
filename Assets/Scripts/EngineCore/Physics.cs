using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Physics : MonoBehaviour
{
    public Physics() { }

    public static CollisionInfo Collision()
    {
        //List<RigidShape> list = new List<RigidShape>();
        var collisionInfo = new CollisionInfo();
        for (int i = 0; i < Core.rigidShapes.Count; i++)
        {
            for (int j = i + 1; j < Core.rigidShapes.Count; j++)
            {
                //if (Core.rigidShapes[i].BoundTest(Core.rigidShapes[j]))
                //{
                //    list.Add(Core.rigidShapes[i]);
                //    list.Add(Core.rigidShapes[j]);
                //}
                if (Core.rigidShapes[i].BoundTest(Core.rigidShapes[j]))
                {
                    if (Circle_Collision.CollisionTest(Core.rigidShapes[i], Core.rigidShapes[j], out collisionInfo))
                    {
                        if(collisionInfo.Normal.Dot(Core.rigidShapes[j].Center.Subtract(Core.rigidShapes[i].Center)) < 0)
                        {
                            collisionInfo.ChangeDir();
                        }
                    }
                }
            }
        }
        return collisionInfo;
    }

}
