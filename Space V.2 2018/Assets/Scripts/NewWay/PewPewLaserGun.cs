using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;

public class PewPewLaserGun : WeaponClass
{
    //Includes Own Targeting System
    Camera PlayerCam;
    GameObject WeaponPoint;
    GameObject Bullet;
    public int BurstFire;
    public float Damage;
    public float Speed;
    public float Radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void shoot(int iterations)
    {
        Ray ray = PlayerCam.ScreenPointToRay(Input.mousePosition);
        for(int i = 0; i <= iterations; i++)
        {
            GameObject PewPew = GameObject.Instantiate(Bullet);
            BulletC Shot = PewPew.GetComponent<BulletC>();
            Shot.Setup(Damage, Speed, Radius);
            Shot.Launch(ray.direction);
        }
    }

}
