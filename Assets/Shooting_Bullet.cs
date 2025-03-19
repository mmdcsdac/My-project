using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Bullet : Bullet
{
    // Start is called before the first frame update
    Rigidbody body;
    Transform Bullet_Transform;
    public Transform transform_;
    public LayerMask true_layer; 
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Bullet_Transform = GetComponent<Transform>();
        Damage = 113;
        true_layer = transform.parent.gameObject.transform.parent.gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Bullet_Transform.rotation = transform_.rotation;
        body.velocity = (transform_.position-Bullet_Transform.position).normalized*5;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer != true_layer)
        {
            Debug.Log(gameObject.name + "|" + 3);
            other.gameObject.GetComponent<Alive_Basic>().HP -= Damage;  
            Destroy(this.gameObject);
            
        }
            
    }
}
