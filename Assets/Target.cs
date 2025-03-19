using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Alive_Basic
{
    // Start is called before the first frame update
    private void Awake()
    {
       gameObject.layer = LayerMask.NameToLayer("Enemy");
    }
    void Start()
    {
        HP = 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
