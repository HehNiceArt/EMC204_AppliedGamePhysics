using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Acc : MonoBehaviour
{
    /*
    public GameObject player, pointB;
    public Rigidbody2D rb;
    public float initVel, finalVel, accelerationPerSecond, time;
    public float dur;
    */
    /*
    public bool haveSpeed, haveDistance, haveTime;
    public float speed, dist, time, timer;
    public Rigidbody2D rb;
    */


    private void Start()
    {
        //       time = 0;
        /*
        if (haveSpeed && haveDistance)
        {
            time = dist / speed;
        }
        else if (haveSpeed && haveTime)
        {
            dist = speed * time;
        }
        else if (haveDistance && haveTime) 
        { 
         speed = dist / time;
        }
        */

    }
    private void Update()
    {
        /*time += Time.deltaTime;
        //gets the dist between player and target
        rb.velocity = Vector2.Lerp(new Vector2(initVel, 0), new Vector2(finalVel, 0), time / dur);;
        */
        /*
        timer *= Time.deltaTime;
        if(timer < time)
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        */

    }
}
