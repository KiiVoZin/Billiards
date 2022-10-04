using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timePeriod;
    [SerializeField] float Power, Friction;
    List<RigidCircleUnity> RigidCircles;
    float counter;
    Core core;
    GameObject cueBall;


    public Vector2 gameAreaMin = new Vector2(-9, -5);
    public Vector2 gameAreaMax = new Vector2(9, 5);

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        RigidCircles = GameObject.FindObjectsOfType<RigidCircleUnity>().ToList();
        core = new Core(Friction);
        for (int i = 0; i < RigidCircles.Count; i++)
        {
            core.rigidShapes.Add(RigidCircles[i].RigidShape);
            if (RigidCircles[i].tag == "Cue Ball") cueBall = RigidCircles[i].gameObject;
            RigidCircles[i].RigidShape.UpdateMass(0);
            RigidCircles[i].RigidShape.Center = new Vec2(RigidCircles[i].gameObject.transform.position.x, RigidCircles[i].gameObject.transform.position.y);
            RigidCircles[i].RigidShape.Radius = RigidCircles[i].gameObject.transform.localScale.x/2;
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
            core.RunGameLoop(timePeriod,gameAreaMin,gameAreaMax);
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
        if (!Input.GetMouseButtonDown(0)) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 target = Vector2.ClampMagnitude((mousePos - (Vector2)cueBall.transform.position), Power);
        cueBall.GetComponent<RigidCircleUnity>().RigidShape.Velocity = new Vec2(target.x, target.y);
    }

    private void OnDrawGizmosSelected()
    {
        var p1 = new Vector2(gameAreaMin.x, gameAreaMin.y);
        var p2 = new Vector2(gameAreaMin.x, gameAreaMax.y);
        var p3 = new Vector2(gameAreaMax.x, gameAreaMax.y);
        var p4 = new Vector2(gameAreaMax.x, gameAreaMin.y);


        Debug.DrawLine(p1, p2, Color.red);
        Debug.DrawLine(p2, p3, Color.red);
        Debug.DrawLine(p3, p4, Color.red);
        Debug.DrawLine(p4, p1, Color.red);

    }
}
