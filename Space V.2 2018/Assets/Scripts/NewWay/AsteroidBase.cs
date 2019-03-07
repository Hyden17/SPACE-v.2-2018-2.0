using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

public class AsteroidBase : WorldObject
{
    public string ASTER_CTLName = "ACM";
    public readonly bool pregenerated;
    public string[] modelspecifiers;
    public GameObject model;
    public GameObject droploot;
    public GameObject effect;
    public Range speed;
    public bool ismoving;

    public bool UseDefaultVector = false;
    public Range[] Scale = new Range[3];
    public Vector3 TravelDirection = new Vector3();
    public AsteroidController ACM;
    // Start is called before the first frame update

    
    void Onkill()
    {
      
    }

    // Update is called once per frame



    void Start()
    {
        RB = GetComponent<Rigidbody>();
        AsteroidController ACM = GameObject.Find(ASTER_CTLName).GetComponent<AsteroidController>();
        if (model == null)
        {
            model = ACM.ReturnAsteroidModel(modelspecifiers, modelspecifiers.Length);
        }
        Launch();
    }


    public void Launch()
    {
        
        
        Instantiate(model, this.transform);
        if (ismoving)
        {
            directionalForce(UseDefaultVector);
            UseGravity(UseJamesGravity);
        }
        

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
