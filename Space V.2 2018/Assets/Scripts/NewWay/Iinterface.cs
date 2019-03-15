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
        void damageObj(float h, GameObject GO);
        void Addforce(Vector3 force);
        void Launch(Vector3 dir);
        float damageNUM
        {
            get;
            set;
        }
        float speed
        {
            get;
            set;
        }
        void Setup(float Damage, float Speed, float Radius);
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