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
            if (shape.Type == "Circle") MyDebug.DrawCircle((Circle)shape, Color.green, 40);
            else if (shape.Type == "Rectangle") MyDebug.DrawRectangle((Rectangle)shape, Color.green);
        }
    }
}
