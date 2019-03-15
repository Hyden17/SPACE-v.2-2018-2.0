using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;

public class WorldObject : MonoBehaviour, IDamageable
{
    //Basic, Add to this later.
    public bool invulnerable;
    public float maxHealth;
    public float health;
    public int Level;
    public Rigidbody RB;
    public Object OnDestroyObject;
    public Vector3 Position;
    public bool UseJamesGravity;
    public string Type;


    public void OnUpdateFunction()
    {



    }
    

    
//Fun Things (Controller References)
    public float spawnrate;
    public bool IsPlayerControlled;
    public Object AIScript;
    public GameObject Controller;
    //CAS-g KS Future Functionality
    public int EnergyMax;
    public Dictionary<string, int> EnergyValues = new Dictionary<string, int>();
    public int[] pattern;

    // Start is called before the first frame update
    public bool kill()
    {
        if( invulnerable != true)
        {
            Destroy(this.gameObject);
        }
        return false;
    }
    
    public void Damage(float h)
    {
        health -= h;
        if(health <= 0)
        {
            kill();
        }
    }

    public void Heal(float h)
    {
        health += h;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
public interface IinteractiveObject<T>
{

}