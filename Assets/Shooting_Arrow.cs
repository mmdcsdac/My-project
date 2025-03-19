using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Arrow : Bullet
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
        Damage = 90;
        //true_layer = transform.parent.gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
       //Bullet_Transform.rotation = transform_.rotation;
        body.velocity = (transform_.position - Bullet_Transform.position).normalized * 20;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != true_layer&&other.gameObject.TryGetComponent<Alive_Basic>(out Alive_Basic alive_))
        {
            Debug.Log(gameObject.name + "|" + 3);
            alive_.HP -= Damage;
            Destroy(this.gameObject);
        }

    }
}
