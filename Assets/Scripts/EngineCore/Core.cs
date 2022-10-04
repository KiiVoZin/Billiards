using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core
{
    public float friction;
    public static Vec2 Gravity;
    public static bool Movement;
    public List<RigidShape> rigidShapes;


    public Core(float friction)
    {
        //Gravity = new Vec2(0, -10f);
        Gravity = new Vec2(0, 0f);
        Movement = false;
        rigidShapes = new List<RigidShape>();
        this.friction = friction;
    }

    public void RunGameLoop(float deltaTime, Vector2 gameboundMin, Vector2 gameboundMax)
    {
        //GET INPUT

        //MOVE
        for (int i = 0; i < rigidShapes.Count; i++)
        {
            Vector2 position = new Vector2(rigidShapes[i].Center.x, rigidShapes[i].Center.y);
            rigidShapes[i].Velocity = rigidShapes[i].Velocity.Add(rigidShapes[i].Acceleration.Scale(deltaTime));
            if (rigidShapes[i].Velocity.Length() <= 1f)
            {
                rigidShapes[i].Velocity = rigidShapes[i].Velocity.Scale(1 - friction*10);
            }
            else
            {
                rigidShapes[i].Velocity = rigidShapes[i].Velocity.Scale(1 - friction);
            }
            rigidShapes[i].Move(rigidShapes[i].Velocity.Scale(deltaTime));

            if (position.x > gameboundMax.x || position.x < gameboundMin.x)
            {
                rigidShapes[i].Velocity = new Vec2(-rigidShapes[i].Velocity.x, rigidShapes[i].Velocity.y);
                rigidShapes[i].Center.x = Mathf.Clamp(position.x,gameboundMin.x,gameboundMax.x);
            }
            if (position.y > gameboundMax.y || position.y < gameboundMin.y)
            {
                rigidShapes[i].Velocity = new Vec2(rigidShapes[i].Velocity.x, -rigidShapes[i].Velocity.y);
                rigidShapes[i].Center.y = Mathf.Clamp(position.y,gameboundMin.y,gameboundMax.y);
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
