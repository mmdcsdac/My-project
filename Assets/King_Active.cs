using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Active : Tower
{
    // Start is called before the first frame update
   public GameObject Bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Active();
    }
    public void Active()
    {
        if(gameObject.layer==LayerMask.NameToLayer("Enemy"))
        {
            if (gameObject.GetComponent<King_Tower>().Camera.GetComponent<Map_Initialize>().Towers_Enemy.Count<2|| gameObject.GetComponent<King_Tower>().HP< 2030)
            {
                gameObject.GetComponent<King_Tower>().isActive = true;
                Debug.Log("Active");
            }
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (gameObject.GetComponent<King_Tower>().Camera.GetComponent<Map_Initialize>().Towers_Player.Count < 2 || gameObject.GetComponent<King_Tower>().HP < 2030)
            {
                gameObject.GetComponent<King_Tower>().isActive = true;
                Debug.Log("Active");
            }
        }

    }

}
