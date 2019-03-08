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
    public bool isScalled = true;
    // Start is called before the first frame update
    public Transform thisTransform;
    
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
        this.transform.localScale = new Vector3(Scale[0].generate(), Scale[1].generate(), Scale[2].generate());

        Debug.Log("This Ran");
    }

    

    void directionalForce(bool UseDefault = false)
    {
        if(UseDefault == false)
        {
            RB.AddForce(new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)) * speed.generate());
        }
        else
        {
            RB.AddForce(TravelDirection * speed.generate());
        }
        RB.AddTorque(new Vector3(Random.Range(0, 3 ), Random.Range(0, 3), Random.Range(0, 3)) * speed.generate());
    }

    void UseGravity(bool grav)
    {
        RB.useGravity = grav;
    }
}
