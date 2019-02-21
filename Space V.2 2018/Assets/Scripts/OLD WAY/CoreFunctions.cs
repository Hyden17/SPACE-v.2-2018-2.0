using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreFunctions3
{
    //Note To Self. Structs must be definied outside of the class for them to work as namespace
    /*  public struct Range
      {
          public float Start1;
          public float End1;
          public Range(float Start, float End)
          {
              Start1 = Start;
              End1 = End;
          }

      }
      public struct LootObject
      {
          public string Name;
          public float SpawnWeight;
          public Object object1;
          public float ProbabilityRangeFrom;
          public float ProbabilityRangeTo;

          public LootObject(string N, float SW, Object Ob = null)
          {
              Name = N;
              SpawnWeight = SW;
              object1 = Ob;
              ProbabilityRangeFrom = 0f;
              ProbabilityRangeTo = 0f;
          }
      }*/
    public struct Range
    {
        public float Start1;
        public float End1;
        public Range(float Start, float End)
        {
            Start1 = Start;
            End1 = End;
        }

    }
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

    public class CoreFunctions
    {

        //Note To Self. Structs must be definied outside of the class for them to work as namespace
        /*  public struct Range
          {
              public float Start1;
              public float End1;
              public Range(float Start, float End)
              {
                  Start1 = Start;
                  End1 = End;
              }

          }
          public struct LootObject
          {
              public string Name;
              public float SpawnWeight;
              public Object object1;
              public float ProbabilityRangeFrom;
              public float ProbabilityRangeTo;

              public LootObject(string N, float SW, Object Ob = null)
              {
                  Name = N;
                  SpawnWeight = SW;
                  object1 = Ob;
                  ProbabilityRangeFrom = 0f;
                  ProbabilityRangeTo = 0f;
              }
          }*/
        //Note -- Unstable. Use Wisely.
        public void CopyValues<T>(T target, T source)
        {
            Type t = typeof(T);
            var properties = t.GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                {
                    prop.SetValue(target, value, null);
                }
            }

        }
        
        public List<object> GetReas(string ASFP)
        {
            
            
            List<object> returnLst = new List<object>();
            object[] TempArray = Resources.LoadAll(ASFP);
            
            foreach (object NewObj in TempArray)
            {
                    returnLst.Add((NewObj));
                    Debug.Log("Added Astroid:  To Astroid Prefabs");   
            }

            return returnLst;

        }



    }
 /*
        //An Experiment in using lists. -- I know. It was about time.
        public (List<LootObject>, LootObject[]) GenerateLootFromTable(LootObject[] table, float SetMax = 0f, bool SavedTable = false, int iterations = 1) //If saved table is true, then the Range values have already been aisgned. Preformance Saver.
        {
            //LootObject[] ReturnTable = default(LootObject[]); Depreciated
            List<LootObject> ReturnTable = new List<LootObject>();
            float TempMax = 1f; //Must be one so that TempMax does not read NullValues
            float NullValue = 0;
            if (SavedTable == false)
            {
                for(int i = 0; i <= table.Length; i++)
                {
                    //A bit confusing so hear me out
                    //Sets the lowest member of the spawn range to the old vaule of tempmax
                    table[i].ProbabilityRangeFrom = TempMax;
                    //Adds this spawn weight to temp max --> This sets the middle area of the objects spawn range.
                    TempMax += table[i].SpawnWeight;
                    //Adds the middle area of the spawn range to the table object by adding the new upper bound of TempMax
                    table[i].ProbabilityRangeTo = TempMax;
                    //Finished adding spawn ranges
                }
            }
            else
            {
                TempMax = table[table.GetLength(0)].ProbabilityRangeTo; //Gets the max spawn value by registering the last member of the array (Which would have been assigned its ProbabilityRangeTo Last)
            }
            if(SetMax > TempMax)
            {
                table[table.GetLength(0) + 1] = new LootObject("Don't Spawn", (SetMax - TempMax), null);
            }
            //Iterations is the number of items to be generated  from table

            for(int i = 0; i <= iterations; i++)
            {
                float SPAWNvalue = UnityEngine.Random.Range(1f, TempMax);
                foreach (LootObject item in table)
                {
                    if ((item.ProbabilityRangeFrom <= SPAWNvalue) && (SPAWNvalue <= item.ProbabilityRangeTo))
                    {
                        ReturnTable.Add(item);
                    }
                }
            }

            return(ReturnTable, table);

        }

        public (List<LootObject>, List<LootObject>) GenLootFromTableADV(List<LootObject> table, float SetMax = 0f, bool SavedTable = false, int iterations = 1) //If saved table is true, then the Range values have already been aisgned. Preformance Saver.
        {
            //LootObject[] ReturnTable = default(LootObject[]); Depreciated
            List<LootObject> ReturnTable = new List<LootObject>();
            float TempMax = 1f; //Must be one so that TempMax does not read NullValues
            float NullValue = 0;
            if (SavedTable == false)
            {
                foreach(LootObject item in table)
                {
                    //A bit confusing so hear me out
                    //Sets the lowest member of the spawn range to the old vaule of tempmax
                    item.ProbabilityRangeFrom = TempMax;
                    //Adds this spawn weight to temp max --> This sets the middle area of the objects spawn range.
                    TempMax += item.SpawnWeight;
                    //Adds the middle area of the spawn range to the table object by adding the new upper bound of TempMax
                    item.ProbabilityRangeTo = TempMax;
                    //Finished adding spawn ranges
                }
            }
            else
            {
                TempMax = table[table.Count-1].ProbabilityRangeTo; //Gets the max spawn value by registering the last member of the array (Which would have been assigned its ProbabilityRangeTo Last)
            }
            if (SetMax > TempMax)
            {
                table.Add(new LootObject("Don't Spawn", (SetMax - TempMax), null));
            }
            //Iterations is the number of items to be generated  from table

            for (int i = 0; i <= iterations; i++)
            {
                float SPAWNvalue = UnityEngine.Random.Range(1f, TempMax);
                foreach (LootObject item in table)
                {
                    if ((item.ProbabilityRangeFrom <= SPAWNvalue) && (SPAWNvalue <= item.ProbabilityRangeTo))
                    {
                        ReturnTable.Add(item);
                    }
                }
            }

            return (ReturnTable, table);

        }

    }*/
}