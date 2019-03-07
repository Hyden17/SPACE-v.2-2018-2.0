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
    [SerializeField] public float AsteroidSpread;
    AsteroidGenerator AsterGen = new AsteroidGenerator();
    LootTable AsterTable = new LootTable();
    LootTable LevelEnemies = new LootTable();
    List<Vector3> AstPosTable = new List<Vector3>();
    CoreFunctions CF3 = new CoreFunctions();
    public bool isGen = false;
    int PreGenAstCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenAsteroidFeildLeve1(AsterTableCollection1, arenasize, Centercoords, AsteroidSpread, 200);
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    void GenAsteroidFeildLeve1(SerializePairGONE[] AsteroidTable,float _arenasize, Vector3 _centercoords, float asteroidSpread, int _conflictcount = 200) 
    {
        LootTable AsteroidTemp = Create_Kaise_Loot_Table(AsteroidTable, ExtraAster);
        int _AsteroidCount = CountAster(AsteroidTable, ExtraAster);
        AstPosTable = AsterGen.SpherePOS(_AsteroidCount, _arenasize, _centercoords, asteroidSpread, _conflictcount);
        List<GameObject> TempList= CF3.Object_to_GameObject(AsteroidTemp.GenJoshLoot(AstPosTable.Count));
        
        for(int i = 0; i < AstPosTable.Count; i++)
        {
            Instantiate<GameObject>(TempList[i], AstPosTable[i], CF3.RandQuaternion());
        }


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

   


    LootTable Create_Kaise_Loot_Table(SerializePairGONE[] inTable, SerializePairGONE ExtraObject)
    {
        LootTable OutTable = new LootTable();
        PreGenAstCount = 0;
        foreach (SerializePairGONE obj in inTable)
        {
            for (int i = 1; i <= obj.Number; i++)
            {
                OutTable.AddItem(obj.Object.name, obj.Object);
            }
        }
        for(int i = 1; i <= ExtraObject.Number; i++)
        {
            OutTable.AddItem(ExtraObject.Object.name, ExtraObject.Object);
        }
        Debug.LogWarning("RUN WHILE YOU STILL CAN... See code 'LootGen' ");
        return OutTable;
    }
}