using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

public class AsteroidBase : WorldObject
{
    public readonly bool pregenerated;
    public string[] modelspecifiers;
    public GameObject model;
    public GameObject droploot;
    public GameObject effect;
    public Range speed;
    public bool ismoving;
    public bool gravity = false;
    public bool UseDefaultVector = false;
    public Range[] Scale = new Range[3];

    [HideInInspector]
    Vector3 TravelDirection = new Vector3();
    // Start is called before the first frame update

    
    void Onkill()
    {
      
    }

    // Update is called once per frame


    public void Launch()
    {
        Instantiate(model, this.transform);
        Instantiate(model, this.transform);
        directionalForce(UseDefaultVector);
        UseGravity(gravity);

    }


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

    void UseGravity(bool grav)
    {
        RB.useGravity = grav;
    }
}
