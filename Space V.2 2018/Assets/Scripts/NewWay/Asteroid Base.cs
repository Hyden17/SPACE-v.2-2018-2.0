using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

public class AsteroidBase : WorldObject
{
    GameObject model;
    GameObject droploot;
    GameObject effect;
    Range speed;
    bool ismoving;
    bool gravity = false;
    bool UseDefaultVector = false;


    [HideInInspector]
    Vector3 TravelDirection = new Vector3();
    // Start is called before the first frame update

    
    void Onkill()
    {
     
    }

    // Update is called once per frame
    
    
    void directionalForce(bool UseDefault = false)
    {
        if(UseDefault == false)
        {
            RB.AddForce(new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1)) * Random.Range(speed.Start1, speed.End1));
        }
        else
        {
            RB.AddForce(TravelDirection * Random.Range(speed.Start1, speed.End1));
        }
    }

    void Gravity(bool grav)
    {
        RB.useGravity = grav;
    }



}
