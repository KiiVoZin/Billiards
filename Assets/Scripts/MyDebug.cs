using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyDebug
{
    public static void DrawCircle2(Vector3 position, float radius, Color color, float time, int nStep)
    {
        float angleStep = 360 / nStep;
        Quaternion rotateQuat;
        Quaternion rotateQuat2;
        Vector3 firstPos;
        Vector3 secondPos;

        for (int i = 0; i <= nStep; i++)
        {
            rotateQuat = Quaternion.AngleAxis(angleStep * i, Vector3.forward);
            rotateQuat2 = Quaternion.AngleAxis(angleStep * (i + 1), Vector3.forward);
            firstPos = position + rotateQuat * Vector3.left * radius;
            secondPos = position + rotateQuat2 * Vector3.left * radius;
            Debug.DrawLine(firstPos, secondPos, color, time);
        }

    }
    public static void DrawCircle(Circle circle, Color color, int nStep)
    {
        float angleStep = 360 / nStep;
        Quaternion rotateQuat;
        Quaternion rotateQuat2;
        Vector3 firstPos;
        Vector3 secondPos;
        for (int i = 0; i <= nStep; i++)
        {
            rotateQuat = Quaternion.AngleAxis(angleStep * i, Vector3.forward);
            rotateQuat2 = Quaternion.AngleAxis(angleStep * (i + 1), Vector3.forward);
            firstPos = new Vector3(circle.Center.x, circle.Center.y, 0) + rotateQuat * Vector3.left * circle.Radius;
            secondPos = new Vector3(circle.Center.x, circle.Center.y, 0) + rotateQuat2 * Vector3.left * circle.Radius;
            Debug.DrawLine(firstPos, secondPos, color);
        }
    }

    //public static void DrawRectangle(Rectangle rectangle, Color color)
    //{
    //    Vector3[] v3Vertexes = new Vector3[4];
    //    for (int i = 0; i < 4; i++) v3Vertexes[i] = new Vector3(rectangle.Vertexes[i].x, rectangle.Vertexes[i].y, 0);
    //    Debug.DrawLine(v3Vertexes[0], v3Vertexes[1], color);
    //    Debug.DrawLine(v3Vertexes[1], v3Vertexes[2], color);
    //    Debug.DrawLine(v3Vertexes[2], v3Vertexes[3], color);
    //    Debug.DrawLine(v3Vertexes[3], v3Vertexes[0], color);
    //}
}
