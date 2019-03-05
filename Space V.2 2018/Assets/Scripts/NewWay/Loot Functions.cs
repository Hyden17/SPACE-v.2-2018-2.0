using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreFunctions3;

namespace LootFunctions
{
    public class LootObject
    {
        public string Name;
        public float SpawnWeight;
        public object object1;
        public float ProbabilityRangeFrom;
        public float ProbabilityRangeTo;

        public LootObject(string N, float AddSpawnWeight = 1, object Ob = null)
        {
            Name = N;
            SpawnWeight = AddSpawnWeight;
            object1 = Ob;
            ProbabilityRangeFrom = 0f;
            ProbabilityRangeTo = 0f;
        }
    }

    public class LootTable
    {

        public List<LootObject> Loots = new List<LootObject>();
        float HardMax = 0;
        float TempMax = 0;

        public void AddItem(string name, object obj = null, float weight = 1)
        {
            LootObject Temploot = new LootObject(name, weight, obj);
            AddItemToTable(Temploot);
            
        }

        public void AddTable(List<LootObject> table)
        {
            foreach (LootObject item in table)
            {

                AddItemToTable(item);
            }
        }

        void AddItemToTable(LootObject item)
        {
            //A bit Complicated so hear me out
            item.ProbabilityRangeFrom = HardMax;
            HardMax += item.SpawnWeight;
            item.ProbabilityRangeTo = HardMax;
            Loots.Add(item);
        }

        void RemoveItemFromTable(LootObject item)
        {
            //Also bit Complicated so hear me out
            //Mostly recalculating the entire loot table
            Loots.Remove(item);
            HardMax = 0;
            foreach (LootObject tempitem in Loots)
            {
                item.ProbabilityRangeFrom = HardMax;
                HardMax += item.SpawnWeight;
                item.ProbabilityRangeTo = HardMax;
                Loots.Add(item);
            }
        }

        List<object> GenJoshLoot(int iterations) //Dose Not remove when generated
        {
            List<object> ReturnTable = new List<object>();
            for (int i = 0; i <= iterations; i++)
            {
                float SPAWNvalue = UnityEngine.Random.Range(1f, TempMax);
                foreach (LootObject item in Loots)
                {
                    if ((item.ProbabilityRangeFrom <= SPAWNvalue) && (SPAWNvalue <= item.ProbabilityRangeTo))
                    {
                        ReturnTable.Add(item.object1);
                        Debug.LogWarning("Heaphalumps and Woosals");
                    }
                }
            } 
            return ReturnTable;
        }

        List<object> GenJamesLoot(int iterations) //Removes Item Once Generated
        {

            List<object> ReturnTable = new List<object>();
            for (int i = 0; i <= iterations; i++)
            {
                float SPAWNvalue = UnityEngine.Random.Range(1f, TempMax);
                foreach (LootObject item in Loots)
                {
                    if ((item.ProbabilityRangeFrom <= SPAWNvalue) && (SPAWNvalue <= item.ProbabilityRangeTo))
                    {
                        ReturnTable.Add(item.object1);
                        RemoveItemFromTable(item);
                    }
                }
            }
            Debug.LogWarning("Just Saying...This Table is now obsolete");
            return ReturnTable;
        }

    }








    public class LootFunctions : MonoBehaviour
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
