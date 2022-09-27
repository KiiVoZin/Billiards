using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] float timePeriod;
    List<GameObject> Balls;
    float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        Balls = GameObject.FindGameObjectsWithTag("Ball").ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fixed update
        counter += Time.deltaTime;
        while (counter >= timePeriod)
        {
            counter -= timePeriod;
            //Do fixed update shenanigans here
            Core core = new Core();
        }

        //Update
    }

}
