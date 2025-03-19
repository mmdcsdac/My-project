//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class Solider_UI : Basic
//{
//    System.Random random;
//    public static List<int> a;
//    public static int point;
//    // Start is called before the first frame update
//    private void Awake()
//    {
//        random = new System.Random();
//        point = 0;
//        a = Map_Initialize.Set_Cards(random);
//    }
//    void Start()
//    {
//        Change_Image(a);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//}
//    public void Change_Image(List<int> a)
//    {
//        Sprite j = null;

//        for (int i = 0; i < a.Count; i++)
//            Debug.Log(a[i]);
//        GetComponent<Image>().sprite = Arts[Map_Initialize.Basic_Card_Carried[a[point]]];


//        //GetComponent<Image>().sprite = ;//Resources.Load<Sprite>("Assets/Resource/OIP-C.jpg");
//        point++;
//        if (point == 5)
//        {
//            a = Map_Initialize.Set_Cards(random);
//            point = 0;
//        }
//    }
//}
