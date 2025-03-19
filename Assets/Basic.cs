using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public static Dictionary<string, Sprite> Arts = new Dictionary<string, Sprite>();
    public bool isAlive;
    public static Dictionary<string, GameObject> P = new Dictionary<string, GameObject>();
    
    // Start is called before the first frame update
    private void Awake()
    {
       
        Arts.Add("GunFirer", Resources.Load<Sprite>("Soldier/OIP_C"));
        Arts.Add("Knight", Resources.Load<Sprite>("Soldier/a6ff43f8c29bd8118259f16e1f5d49a"));
        Arts.Add("Goblin_House", Resources.Load<Sprite>("Soldier/f06790bb5c3a4bbc4f62bde62731001"));        
        Arts.Add("FireBall", Resources.Load<Sprite>("Soldier/0cf06de9c7a2edddadfc2db45969dbb"));
        Arts.Add("ArrowRain", Resources.Load<Sprite>("Soldier/9d028f57ce11b2ea0ccbea70366ae5a"));
        Arts.Add("Goblin_Team", Resources.Load<Sprite>("Soldier/090538592ea491c9cd2e0ddc6717d15"));
        Arts.Add("Archer", Resources.Load<Sprite>("Soldier/download"));
        Arts.Add("Giant", Resources.Load<Sprite>("Soldier/R_C"));
        P.Add("GunFirer", Resources.Load<GameObject>("Soliders/body"));
        P.Add("Knight", Resources.Load<GameObject>("Soliders/Knight"));
        P.Add("Goblin", Resources.Load<GameObject>("Soliders/Gobline_House"));
        P.Add("FireBall", Resources.Load<GameObject>("Soliders/FireBall_True"));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
