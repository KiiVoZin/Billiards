using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public List<RigidShape> rigidShapes;
    public Core()
    {
        rigidShapes = new List<RigidShape>();
    }

    public void RunGameLoop()
    {
        foreach(RigidShape shape in rigidShapes)
        {
            if (shape.Type == "Circle") MyDebug.DrawCircle(shape, Color.green, 40);
        }
    }
}
