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

        void AddTable(List<LootObject> table)
        {
            foreach (LootObject item in table)
            {

                AddItem(item);
            }
        }

        void AddItem(LootObject item)
        {
            //A bit Complicated so hear me out
            item.ProbabilityRangeFrom = HardMax;
            HardMax += item.SpawnWeight;
            item.ProbabilityRangeTo = HardMax;
            Loots.Add(item);
        }

        List<object> GenJoshLoot(int iterations)
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
                    }
                }
            }
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
