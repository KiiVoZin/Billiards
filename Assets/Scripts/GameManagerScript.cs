using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timePeriod;
    [SerializeField] GameObject Ball;
    List<RigidCircleUnity> RigidCircles;
    float counter;
    Core core;
    Vector2 mouseFirstPos;
    Vector2 mouseSecondPos;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        RigidCircles = GameObject.FindObjectsOfType<RigidCircleUnity>().ToList();
        core = new Core();
        for (int i = 0; i < RigidCircles.Count; i++)
        {
            core.rigidShapes.Add(RigidCircles[i].RigidShape);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Fixed update
        counter += Time.deltaTime;
        while (counter >= timePeriod)
        {
            //Do fixed update shenanigans here
            core.RunGameLoop(timePeriod);
            counter -= timePeriod;
        }
        Sync();
        Shoot();
        //Update
        core.Draw();
    }

    public void Sync()
    {
        for (int i = 0; i < RigidCircles.Count; i++)
        {
            RigidCircles[i].transform.position = RigidCircles[i].RigidShape.Center.ToVector3();
        }
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0)) mouseFirstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            mouseSecondPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouseFirstPos);
            Debug.Log(mouseSecondPos);
            GameObject rigidCircle = Instantiate(Ball);
            RigidCircleUnity rigidCircleUnity = rigidCircle.GetComponent<RigidCircleUnity>();
            rigidCircleUnity.RigidShape = new Circle(Vec2.ToVec2(mouseFirstPos), 0.1f, 1, 0, 0.5f);

            if (Vector2.Distance(mouseFirstPos, mouseSecondPos) > 1)
            {
                rigidCircleUnity.RigidShape.Velocity = Vec2.ToVec2(mouseSecondPos - mouseFirstPos).Normalize();
            }
            RigidCircles.Add(rigidCircleUnity);
            core.rigidShapes.Add(rigidCircleUnity.RigidShape);
        }
    }
}
