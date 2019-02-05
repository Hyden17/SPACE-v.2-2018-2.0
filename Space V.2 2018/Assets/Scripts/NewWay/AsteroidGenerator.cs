using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

public class AsteroidGenerator : MonoBehaviour
{
    public CoreFunctions CoreFunction = new CoreFunctions();
    public string AsteroidFilePath;
    public List<GameObject> AsteroidPrefabs = new List<GameObject>();
 //Storage for the randomly generated asteroids to asign to objects
    public int AvalibleGens = 0;
    public int RegenAvalible = 40;
    bool initGenTable = false;





    public int NumberOfAstroids;
    public Vector3 centerCoords;
    public GameObject PlayFeild;
    public GameObject player;
    public enum AstroidFeild { Sphere, Torus, Mirrored, Falling };
    public AstroidFeild AstroidState;
    public float astroidSpread;
    public float ArenaSize;
    public GameObject[] AstroidsGen;
    public int ConflictCountMax = 200;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    void GenAsteroidFieldInit()
    {
        AsteroidPrefabs = CoreFunction.GetReas(AsteroidFilePath);
        

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
