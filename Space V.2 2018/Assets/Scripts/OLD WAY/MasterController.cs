using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public string Gamemode = "";
    public string Gamestate = "";
    public int GamestateID = 0;
    public Dictionary<string, GameObject> Gamestates = new Dictionary<string, GameObject>();
    protected GameObject ValueGSO;

    
    public struct GamestatesEdit1
    {
        public string key;
        public GameObject Gameobject;
    }

    [SerializeField]  public GamestatesEdit1[] GamestatesEdit;


    // Start is called before the first frame update
    void Start()
    {
        foreach(var GS in GamestatesEdit)
        {
            Gamestates.Add(GS.key, GS.Gameobject);
        }
        //For testing purposes the UI and menu states are not Run At start
        // In future runs, please set the menu state to start at startup
        foreach (var GM in Gamestates)
        {
            if((GM.Key == Gamemode) && (Gamestates.TryGetValue(GM.Key, out ValueGSO )))
            {
                Instantiate(ValueGSO, new Vector3(0,0,0), Quaternion.identity);
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
