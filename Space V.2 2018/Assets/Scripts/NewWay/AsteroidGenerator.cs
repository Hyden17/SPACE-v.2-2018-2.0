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

    List<Vector3> AstroidSpherePOS()
    {
        List<Vector3> AstroidPosLst = new List<Vector3>();
        int CoordCount = NumberOfAstroids;
        bool IsConflict = false;
        int ConflictCount = 0;
        for (int x = 0; x < CoordCount; x++)
        {
            IsConflict = false;
            Vector3 NewPos = new Vector3(0, 0, 0) + centerCoords;
            NewPos = NewPos + Random.insideUnitSphere * ArenaSize;
            foreach (Vector3 TryPos in AstroidPosLst)
            {
                if ((NewPos - TryPos).magnitude < astroidSpread)
                {
                    IsConflict = true;
                    break;
                }
            }
            if (IsConflict == true)
            {
                CoordCount++;
                ConflictCount++;

            }
            else
            {
                AstroidPosLst.Add(NewPos);
            }
            if (ConflictCount > ConflictCountMax)
            {
                Debug.Log("Generated Over" + ConflictCount + "Conflicts, Lower astroid number or rase Feild Size.");
                break;
            }
        }
        Debug.Log("Succesfully Generated:" + AstroidPosLst.Count + "Coordinates");
        return AstroidPosLst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
