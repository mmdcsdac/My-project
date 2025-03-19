using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Map_Initialize : Basic
{
    public float t = 0.001f;
    public static List<GameObject> Player_Soliders = new List<GameObject>();
    public System.Random random;
    [Header("Lists")]
    public static float SanWater_Player;
    public static float SanWater_Enemy;
    public GameObject SanWaterPlayer_UI;
    public static List<string> Card_Carried;
    public static List<string> Basic_Card_Carried;
    public static List<Image> Solider_UI_Image;
    public  List<List<GameObject>> Towers = new List<List<GameObject>>();
    public  List<GameObject> Towers_Enemy;
    public  List<GameObject> Towers_Player;
    public List<Image> ButtonList;
    public GameObject Left_AI;
    public GameObject Right_AI;
    // Start is called before the first frame update
    private void Awake()
    {
        List<int> a = Set_Cards();
        Basic_Card_Carried = new List<string>
        {
           "GunFirer","Giant","Goblin_Team","Goblin_House","Archer","FireBall","ArrowRain","Knight"
        };
        ButtonList = new List<Image>();
        for (int i = 0; i < 4; i++)
        {
            ButtonList.Add(GameObject.Find("Button" + (i + 1)).GetComponent<Image>());
            ButtonList.ElementAt(i).sprite = Basic.Arts[Map_Initialize.Basic_Card_Carried.ElementAt(a[i])];
        }
        SanWater_Enemy = 6;
        SanWater_Player = 6;

    }
    void Start()
    {



       // Towers.Add(Towers_Player);
        //Towers.Add(Towers_Enemy);

        random = new System.Random();
        Solider_UI_Image = new List<Image>();

        //Towers = new List<List<GameObject>>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Set_SanWater();
        AI();
    }
    public void Set_SanWater()
    {
        SanWaterPlayer_UI.GetComponent<Slider>().value = SanWater_Player;
        if (SanWater_Player<10)
        {
            SanWater_Player += Time.deltaTime;
        }
        if(SanWater_Enemy<10)
        {
            SanWater_Enemy += Time.deltaTime;
        }
        
    }
    public static List<int> Set_Cards()
    {
        List<int> a = new List<int>();
        //int[] a = new int[4];
        //a[1] = 0;
        //a[2] = 0;
        //a[3] = 0;
        //for (int i = 0; i < 4; i++)
        //{

        //    a[i] = r.Next(1, 8);
        //    Array.Sort(a);
        //    for (int j = 1; j < 4; j++)
        //    {
        //        if(a[j] == a[j - 1])
        //        {
        //            i = i - 1;
        //        }
        //    }
        //}
        for(int i = 0; i < 8; i++)
        {
            a.Add(i);
        }
        a = a.OrderBy(i => Guid.NewGuid()).ToList();
        return a;
    }
    public void AI()
    {
        for (int i = 0; i < Player_Soliders.Count; i++)
        {
            Debug.Log(Player_Soliders[i].name+"AI");
            if (Player_Soliders[i] == Basic.P["GunFirer"] && SanWater_Enemy >= 4)
            {
                if (Player_Soliders[i].transform.position.x <= 1.88f)
                {
                    Instantiate(Basic.P["Knight"], Left_AI.transform.position, new Quaternion(0, 1, 0, 0));
                    Player_Soliders.RemoveAt(i);
                }
                else
                {
                    Instantiate(Basic.P["Knight"], Right_AI.transform.position, new Quaternion(0, 1, 0, 0));
                    Player_Soliders.RemoveAt(i);
                }
            }
            if (Player_Soliders[i] == Basic.P["Knight"] && SanWater_Enemy >= 5)
            {
                if (Player_Soliders[i].transform.position.x <= 1.88f)
                {
                    Instantiate(Basic.P["Gobline_House"], Left_AI.transform.position, new Quaternion(0, 1, 0, 0));
                    Player_Soliders.RemoveAt(i);
                }
                else
                {
                    Instantiate(Basic.P["Gobline_House"], Right_AI.transform.position, new Quaternion(0, 1, 0, 0));
                    Player_Soliders.RemoveAt(i);
                }
            }

        }
    }

}
