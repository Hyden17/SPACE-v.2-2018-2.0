using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

public class AsteroidGenerator
{
    public CoreFunctions CoreFunction = new CoreFunctions();
    public string AsteroidFilePath;
    public List<object> AsteroidPrefabs = new List<object>();
    public Vector3 centerCoords;
    public enum AstroidFeild { Sphere, Torus, Mirrored, Falling };
    public AstroidFeild AstroidState;
    
    public GameObject[] AstroidsGen;
    public int ConflictCountMax = 200;



    // Start is called before the first frame update
    void Start()
    {

    }
    
    public List<Vector3> SpherePOS(int Count, float arenasize, Vector3 centercoords, float Spread, int conflictcount )
    {
        List<Vector3> AstroidPosLst = new List<Vector3>();
        int CoordCount = Count;
        bool IsConflict = false;
        int ConflictCount = 0;
        for (int x = 0; x < CoordCount; x++)
        {
            IsConflict = false;
            Vector3 NewPos = new Vector3(0, 0, 0) + centercoords;
            NewPos = NewPos + Random.insideUnitSphere * arenasize;
            foreach (Vector3 TryPos in AstroidPosLst)
            {
                if ((NewPos - TryPos).magnitude < Spread)
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

    public void GenAsteroidFieldInit()
    {
        AsteroidPrefabs = CoreFunction.GetReas(AsteroidFilePath);
        foreach (object AsterObject in AsteroidPrefabs)
        {
            if (AsterObject.GetType() != typeof(GameObject))
            {
                AsteroidPrefabs.Remove(AsterObject);
            }
        }
    }

    void Update()
    {
        
    }

}
