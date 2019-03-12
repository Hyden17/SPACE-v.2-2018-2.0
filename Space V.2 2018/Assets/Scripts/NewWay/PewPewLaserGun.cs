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
    int BurstFire;
    float Damage;


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
            
        }
    }

}
