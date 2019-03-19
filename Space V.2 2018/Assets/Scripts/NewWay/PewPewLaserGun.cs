using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;
using TimeMngr;

public class PewPewLaserGun : WeaponClass
{
    //Includes Own Targeting System
    public Camera PlayerCam;
    public GameObject Bullet;
    public float CoolDown;
    public int BurstFire;
    public float Damage;
    public float Speed;
    public float Radius;
    public string FireButton = "E";
    private float NewSpeed;

    Timer Cooltimer;
    // Start is called before the first frame update
    void Start()
    {
        Cooltimer.SetTime(CoolDown);
        Cooltimer.ForceFinish();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("e"))
        {
            Shoot(BurstFire);
        }
           
        
    }


    void Shoot(int iterations)
    {
        if(Bullet.GetComponent<Ishootable>() != null)
        {

        
            Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
            for(int i = 0; i <= iterations; i++)
            {
                GameObject PewPew = GameObject.Instantiate(Bullet, (Vector3) this.gameObject.transform.position, Quaternion.identity);
                Ishootable Shot = PewPew.GetComponent<Ishootable>();
                NewSpeed  = Speed +  this.gameObject.GetComponentInParent<Rigidbody>().velocity.magnitude;
                Shot.Setup(Damage, NewSpeed, Radius);
                Shot.Launch(ray.direction);
            }
        }
    }

}
