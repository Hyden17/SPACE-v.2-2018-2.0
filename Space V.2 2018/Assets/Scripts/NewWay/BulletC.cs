using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;
public class BulletC : MonoBehaviour, Ishootable
{
    Rigidbody rb;
    public bool DestroyOnDamage = true;
    public float damageNUM { get; set; }
    public float speed { get; set; }
    public float radius { get; set; }

// Start is called before the first frame update
    void Start()
    {
        GetRigidBody(out rb);

    }

    void GetRigidBody(out Rigidbody rb)
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }


    public void Setup(float Damage, float Speed, float Radius)
    {
        damageNUM = Damage;
        speed = Speed;
        radius = Radius;
    }




    void SetCollider(float radius)
    {
        if(this.gameObject.GetComponent<Collider>() != null)
        {
            SphereCollider CC = this.gameObject.AddComponent<SphereCollider>();
            CC.isTrigger = true;
            CC.radius = radius;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        IDamageable ID = collision.gameObject.GetComponent<IDamageable>() as IDamageable;
        if (ID != null)
        {

            ID.Damage(damageNUM);

        }

    }



    public void Addforce(Vector3 force)
    {
        rb.AddForce(force * speed);
    }
    public void Launch(Vector3 force)
    {
        rb.AddForce(force * speed);
    }

    public void damageObj(float h, GameObject Go)
    {
        
    }

    
}
