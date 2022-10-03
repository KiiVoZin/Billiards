using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public static Vec2 Gravity;
    public static bool Movement;
    public List<RigidShape> rigidShapes;
    public Core()
    {
        //Gravity = new Vec2(0, -10f);
        Gravity = new Vec2(0, 0f);
        Movement = false;
        rigidShapes = new List<RigidShape>();
    }

    public void RunGameLoop(float deltaTime)
    {
        //GET INPUT

        //MOVE
        for (int i = 0; i < rigidShapes.Count; i++)
        {
            Vector2 position = Camera.main.WorldToViewportPoint(new Vector2(rigidShapes[i].Center.x, rigidShapes[i].Center.y));
            if (position.x < 1 && position.x > 0 && position.y < 1 && position.y > 0)
            {
                rigidShapes[i].Velocity = rigidShapes[i].Velocity.Add(rigidShapes[i].Acceleration.Scale(deltaTime));
                rigidShapes[i].Move(rigidShapes[i].Velocity.Scale(deltaTime));
            }
        }
        Physics.Collision(rigidShapes);
    }
    public void Draw()
    {
        for (int i = 0; i < rigidShapes.Count; i++)
        {
            MyDebug.DrawCircle((Circle)rigidShapes[i], Color.green, 40);
        }
    }
}
