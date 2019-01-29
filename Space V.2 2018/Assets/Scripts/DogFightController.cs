using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFightController : MonoBehaviour
{
    public int NumberOfAstroids;
    public Vector3 centerCoords;
    public GameObject PlayFeild;
    public GameObject player;
    public enum AstroidFeild {Sphere, Torus, Mirrored, Falling};
    public AstroidFeild AstroidState;
    public float astroidSpread;
    public float ArenaSize;
    public GameObject[] AstroidsGen;
    public int ConflictCountMax = 200;

    //Test Pilot
 [SerializeField]   public GameObject[] AstroidsTest;


   // Start is called before the first frame update
    void Start()
    {
        if (AstroidState == AstroidFeild.Sphere)
        {
            //castle
            var AstroidCords = AstroidSpherePOS();
            GenerateFeild(AstroidCords, AstroidsGen);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenerateFeild(List<Vector3> FeildList, GameObject[] AstroidGen)
    {
        foreach(Vector3 CoPoint in FeildList)
        {
            Vector3 rotation3 = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0f, 360.0f), Random.Range(0f, 360.0f));
            int AstroidNumber = Random.Range(0, AstroidGen.Length);
            Instantiate(AstroidGen[AstroidNumber], CoPoint, Quaternion.Euler(rotation3));

        }
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
            NewPos = NewPos + Random.onUnitSphere * Random.Range(0f, ArenaSize);
            foreach (Vector3 TryPos in AstroidPosLst)
            {
                if ((NewPos - TryPos).magnitude < astroidSpread)
                {
                    IsConflict = true;
                    break;
                }
            }
            if(IsConflict == true)
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

}
