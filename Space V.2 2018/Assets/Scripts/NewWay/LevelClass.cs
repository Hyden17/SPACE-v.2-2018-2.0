using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootFunctions;
using CoreFunctions3;

public class LevelClass : MonoBehaviour
{

    [SerializeField] public SerializePairGONE[] AsterTableCollection1;
    [SerializeField] public SerializePairGONE ExtraAster;
    [SerializeField] public Vector3 Centercoords = new Vector3(0, 0, 0);
    [SerializeField] public int AsteroidCount;
    [SerializeField] public float arenasize;
    [SerializeField] public string filepath;

    AsteroidGenerator AsterGen = new AsteroidGenerator();
    LootTable AsterTable = new LootTable();
    LootTable LevelEnemies = new LootTable();
    List<Vector3> AstPosTable = new List<Vector3>();

    int PreGenAstCount = 0;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    int CountAster(SerializePairGONE[] AsterNumber, SerializePairGONE Asternumber2)
    {
        PreGenAstCount = 0;
        foreach(SerializePairGONE obj in AsterNumber)
        {
            PreGenAstCount += obj.Number;
        }
        PreGenAstCount += ExtraAster.Number;
        return PreGenAstCount;
    }
    

    //NOTE: Will use Extra Aster Regardless, Just saying.... The AI's will take over...
    void AsteroidFeildLeve1(SerializePairGONE[] AsteroidTable,float _arenasize, Vector3 _centercoords, float asteroidSpread, int _conflictcount) 
    {
        Create_Kaise_Loot_Table(AsteroidTable, AsterTable, ExtraAster);
        int _AsteroidCount = CountAster(AsteroidTable, ExtraAster);
//      AsterGen.AsteroidFilePath = filepath;
//      AsterGen.GenAsteroidFieldInit();
        AstPosTable = AsterGen.SpherePOS(_AsteroidCount, _arenasize, _centercoords, asteroidSpread, _conflictcount);
        


    }
    void Create_Kaise_Loot_Table(SerializePairGONE[] inTable, LootTable outTable, SerializePairGONE ExtraObject)
    {
        PreGenAstCount = 0;
        foreach (SerializePairGONE obj in inTable)
        {
            for (int i = 1; i <= obj.Number; i++)
            {
                outTable.AddItem(obj.Object.name, obj.Object);
            }
        }
        for(int i = 1; i <= ExtraObject.Number; i++)
        {
            outTable.AddItem(ExtraObject.Object.name, ExtraObject.Object);
        }
        Debug.LogWarning("THE AI's ARE TAKING OVER.... RUN WHILE YOU STILL CAN... See code 'LootGen' ");
    }
}