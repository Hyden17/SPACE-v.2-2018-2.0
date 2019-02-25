/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;


public class AsteroidClass : MonoBehaviour
{
    public string ParentControllerName = ""; //OBJECT WITH PARENT CONTROLLER (MUST HAVE ASTEROID CONTROL)

    public string Type;
    public float health;
    public bool hasRigidbody;
    public string colourRange; 
    public string EnergyType;
    public Range speedRange;
    public Range sizeRange;
    public Transform AsterTransform;
    public GameObject dropitem;
    public GameObject SpecialProperties;
    public GameObject AsteroidPrefab;
    public GameObject MasterAster;
    private AsteroidController MasterScript;
    public AsteroidController.AsteroidDef AsterDef = null;
    public CoreFunctions CF = new CoreFunctions();
    public bool HASSTART = false;
    // Start is called before the first frame update
    void Start()
    {

        if(HASSTART == false)
        {

            DOSOMTHING();
        }
        

    }

    void DOSOMTHING()
    {
        //Yes. I know. MasterAster. It was funny. Just keep reading and move on.
this.gameObject.name = "Hello Bob";
        AsterTransform = gameObject.GetComponent<Transform>();

        MasterAster = GameObject.Find(ParentControllerName);
        MasterScript = MasterAster.GetComponent<AsteroidController>();
        //So this is important. I don't know why I wrote any of this this way... but...
                                                                                                //CF.CopyValues<object>(this, AsterDef);
        //It just is. This ^^^ Grabs the values from our OTHER asteroid class and copies it. 

        
        Instantiate(AsteroidPrefab, AsterTransform);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void HealthManager()
    {


    }

}
*/