using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public static Vec2 Gravity;
    public static bool Movement;
    public static List<RigidShape> rigidShapes;
    public Core()
    {
        Gravity = new Vec2(0, -10f);
        Movement = false;
        rigidShapes = new List<RigidShape>();
        rigidShapes.Add(new Circle(new Vec2(1.1f, -1), 0.3f, 1, 0, 0));
        rigidShapes.Add(new Circle(new Vec2(1, 1), 0.3f, 1, 0, 0));
        //rigidShapes.Add(new Rectangle(new Vec2(-1, -2), 0.3f, 0.9f));
    }

    public void RunGameLoop(float deltaTime)
    {
        //GET INPUT

        //MOVE
        for (int i = 0; i < rigidShapes.Count; i++)
        {
            Vector2 position = Camera.main.WorldToViewportPoint(new Vector2(rigidShapes[i].Center.x, rigidShapes[i].Center.y));
            if (rigidShapes[i].Type == "Circle")
            {
                Circle circle = (Circle)rigidShapes[i];
                if (position.x < 1 && position.x > 0 && position.y < 1 && position.y > 0)
                {
                    rigidShapes[i].Velocity = rigidShapes[i].Velocity.Add(rigidShapes[i].Acceleration.Scale(deltaTime));
                    rigidShapes[i].Move(rigidShapes[i].Velocity.Scale(deltaTime));
                    {
                    }
                    //else if (rigidShapes[i].Type == "Rectangle") MyDebug.DrawRectangle((Rectangle)rigidShapes[i], Color.green);
                }

            }
        }
    }
    public void Draw()
    {
        for (int i = 0; i < rigidShapes.Count; i++)
        {
            //    if (collisions.Contains(rigidShapes[i]))
            //    {
            //        MyDebug.DrawCircle((Circle)rigidShapes[i], Color.red, 40);
            //    }
            //    else
            //    {
            //        MyDebug.DrawCircle((Circle)rigidShapes[i], Color.green, 40);
            //    }
            MyDebug.DrawCircle((Circle)rigidShapes[i], Color.green, 40);
            CollisionInfo collisionInfo = Physics.Collision();
            if (collisionInfo != null)
            {
                Debug.DrawLine(new Vector2(collisionInfo.Start.x, collisionInfo.Start.y), new Vector2(collisionInfo.End.x, collisionInfo.End.y), Color.black);
                //Debug.DrawLine(new Vector2(collisionInfo.Depth,);
            }
        }
    }
}
