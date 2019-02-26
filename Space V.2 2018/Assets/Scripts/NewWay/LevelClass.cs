using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootFunctions;
using CoreFunctions3;

public class LevelClass : MonoBehaviour
{
    
    [SerializeField] public SerializePairGONE[] AsterNumber;
    [SerializeField] public Vector3 Centercoords = new Vector3(0, 0, 0);
    [SerializeField] public int AsteroidCount;
    [SerializeField] public float arenasize;
    [SerializeField] public string filepath;

    AsteroidGenerator AsterGen = new AsteroidGenerator();
    LootTable AsterTable = new LootTable();
    LootTable LevelEnemies = new LootTable();
    List<Vector3> AstPosTable = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AsteroidFeildLeve1(int _AsteroidCount, float _arenasize, Vector3 _centercoords,float asteroidSpread ,int _conflictcount  )
    {
        AsterGen.AsteroidFilePath = filepath;
        AsterGen.GenAsteroidFieldInit();
        AstPosTable = AsterGen.SpherePOS(_AsteroidCount, _arenasize, _centercoords, asteroidSpread, _conflictcount);


    }


}
