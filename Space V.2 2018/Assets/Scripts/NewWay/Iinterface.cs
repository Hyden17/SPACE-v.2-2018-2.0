using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace interfaces { 

interface IDamageable
    {
        bool kill();
        void Damage(float h);
        void Heal(float h);

    }

interface Ishootable
    {

        void Addforce(Vector3 force);
        

    }


public class Iinterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}