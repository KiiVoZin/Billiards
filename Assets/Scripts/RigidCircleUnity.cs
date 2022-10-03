using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RigidCircleUnity : MonoBehaviour
{
    public Circle RigidShape;

    public void Test()
    {
        RigidShape.Mass = 5;
    }

}
