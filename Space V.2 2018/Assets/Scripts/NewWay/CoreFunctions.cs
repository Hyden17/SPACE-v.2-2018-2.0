using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootFunctions;

namespace CoreFunctions3
{
    [Serializable]
    public struct Range
    {
        public float Start1;
        public float End1;
        public Range(float Start, float End)
        {
            Start1 = Start;
            End1 = End;
        }
        public float generate()
        {
            return UnityEngine.Random.Range(Start1, End1);
        }

    }
    [Serializable]
    public struct SerializePairGONE  //GONE  --> GameObject Number Enumerator (Whatever that means... used in random generation as an array
    {
        public GameObject Object;
        public int Number;
        SerializePairGONE(GameObject GO, int NE)
        {
            Object = GO;
            Number = NE;
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


        public List<object> FindObjectOfType(string[] Param, Dictionary<string, object> ObjectList, int CheckCount = 0)
        {
            if (CheckCount >= Param.Length)
            {
                Debug.LogError("CheckCount Is Greater Than Paramaters given. Will not return objects...");
            }
            if (CheckCount == 0) //If no Check Count is specified, assume all string parameters are necessary.
            {
                CheckCount = Param.Length;
            }

            int NewCheckCount = 0;
            List<object> ReturnSet = new List<object>();
            foreach (KeyValuePair<string, object> x in ObjectList) //Cycles Through List of Prefabs  --- Returns Eligable Memebers
            {
                NewCheckCount = 0; //Clears the number of checks
                foreach (string Condition in Param)  //Cycles through Conditions in Param
                {
                    if (x.Key.Contains(Condition))  //If a condition is found ++ Add one
                    {
                        NewCheckCount++;
                    }
                    if (NewCheckCount == CheckCount) //If the minimum number of conditions are met --> Add the game object to the return list and cycle to next Key Value Pair in ObjectList
                    {
                        ReturnSet.Add(x.Value);
                        break;
                    }
                }
            }
            return ReturnSet;
        }

        public Dictionary<string, object> GameObjecttoNameObjDict(List<GameObject> Dealwithit)
        {
            Dictionary<string, object> ReturnDict = new Dictionary<string, object>();
            foreach(GameObject GO in Dealwithit)
            {
                ReturnDict.Add(GO.name, GO as object);
            }
            return ReturnDict;
        }

        public List<GameObject> Object_to_GameObject(List<object> Input)
        {
            List<GameObject> Returnlist = new List<GameObject>();
            foreach(object obj in Input)
            {
                Returnlist.Add(obj as GameObject);
            }
            return Returnlist;
        }

        public Quaternion RandQuaternion()
        {
            Quaternion returnQuat = new Quaternion(UnityEngine.Random.Range(1, 360), UnityEngine.Random.Range(1, 360), UnityEngine.Random.Range(1, 360), UnityEngine.Random.Range(1, 360));
            return returnQuat;
        }
        

        public List<GameObject> ConvenienceLoot(List<GameObject> obj, int count = 1)
        {
            List<GameObject> ReturnList = new List<GameObject>();
            if (count == 1)
            {
                int Num = UnityEngine.Random.Range(0, obj.Count);
                ReturnList.Add(obj[Num]);
                return ReturnList;
            }
            else
            {
                for(int i = 1; i <= count; i++ )
                {
                    int Num = UnityEngine.Random.Range(0, obj.Count);
                    ReturnList.Add(obj[Num]);
                }
            }
            return ReturnList;
        }

        public List<GameObject> FindObjectFromGameObject(string[] Param, List<GameObject> ObjectInput, int CheckCount = 1) //Finds from List of GameObjects
        {
            Dictionary<string, object> ForConvert = GameObjecttoNameObjDict(ObjectInput);
            List<object> SemiReturn = FindObjectOfType(Param, ForConvert, CheckCount);
            List<GameObject> ReturnList = Object_to_GameObject(SemiReturn);
            return ReturnList;
        }
    }
}