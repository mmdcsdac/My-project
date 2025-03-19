using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_Drag : Map_Initialize, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject camera;                
    Sprite s;
    // Start is called before the first frame update
    void Start()
    {
        //camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject prefabToSpawn;
    private GameObject previewObject;
    private bool isDragging = false;
    // ¿ªÊ¼ÍÏ×§
    public void OnBeginDrag(PointerEventData eventData)
    {
        for (int i = 0; i < Basic.Arts.Count; i++)
        {
            if (Basic.Arts[Basic.Arts.Keys.ElementAt(i)] == this.gameObject.GetComponent<UnityEngine.UI.Image>().sprite)
            {
                prefabToSpawn = Basic.P[Basic.P.Keys.ElementAt(i)];
                isDragging = true;
                break;
            }
        }

        if (prefabToSpawn == null)
        {
            Debug.LogWarning("Prefab to spawn is not assigned!");
            return;
        }

        
        previewObject = Instantiate(prefabToSpawn);
        previewObject.SetActive(false); 
        isDragging = true;
    }   

        
        public void OnDrag(PointerEventData eventData)
        {
            if (!isDragging || previewObject == null)
                return;

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                previewObject.SetActive(true);
                previewObject.transform.position = new UnityEngine.Vector3(hit.point.x, -2.5583f, hit.point.z); 
            }
            else
            {
                previewObject.SetActive(false);
            }
        }
        GameObject C;
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isDragging || previewObject == null)
                return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)&&Map_Initialize.SanWater_Player>=prefabToSpawn.GetComponent<Alive_Basic>().Cost)
            {
                Debug.Log(prefabToSpawn.GetComponent<Alive_Basic>().Cost);
                C = Instantiate(prefabToSpawn, previewObject.transform.position, UnityEngine.Quaternion.identity);
                SanWater_Player -= C.gameObject.GetComponent<Alive_Basic>().Cost;
                Player_Soliders.Add(C);
                bool z = true;
                random = new System.Random();

                for (int y = 0; y<1;y++)
                {
                    int p = random.Next(0, 7);
                    s = Basic.Arts.Values.ElementAt(p);                
                    for (int i = 0; i < ButtonList.Count; i++)
                    {
                        if (ButtonList[i].GetComponent<UnityEngine.UI.Image>().sprite == s)
                        {
                            y -= 1;
                        }
                    }
                }
                this.GetComponent<UnityEngine.UI.Image>().sprite = s;
            }
            //Destroy(previewObject.GetComponent<Alive_Basic>().HP_);
            Destroy(previewObject);
            isDragging = false;
        }
    
}

