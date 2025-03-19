using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<FireBall_True>().enabled = true;
        transform.parent.GetComponent<SphereCollider>().enabled = true;
        Destroy(this.gameObject);
    }
}
