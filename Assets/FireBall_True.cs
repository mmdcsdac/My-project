using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_True : MonoBehaviour
{
    // Start is called before the first frame update
    float a = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a += Time.deltaTime;
        if (a>5)
            Destroy(this.gameObject);
    }
}
