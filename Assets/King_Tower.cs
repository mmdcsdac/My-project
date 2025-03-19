using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King_Tower : Alive_Basic
{
    GameObject HP_t;
    public GameObject Bullet;
    public float t = 0;
    public GameObject Camera;
    public bool isActive = false;
    private void Awake()
    {
        HP_ = GameObject.Find("HP");
    }
    void Start()
    {

        Damage = 90;
        Attack_delay = 1;
        Range = 9;
        Attack_time = 0.4f;
        Alive_Initialize();
        isAlive = true;
        Cost = 0;
        HP = 1130;
        HP_t = Instantiate(HP_, this.gameObject.GetComponent<Transform>().position + new Vector3(0, 2, 0), HP_.GetComponent<Transform>().rotation, Cav.transform);
        HP_t.GetComponent<Slider>().maxValue = HP;
        HP_t.GetComponent<Slider>().value = HP;

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        Shoot();
        HP_t.GetComponent<Slider>().value = HP;
        Dead(HP_t);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer)
        {
            Touch = other.gameObject;
            Debug.Log(gameObject.name + "|" + Touch.gameObject.name);
        }
        else
            Touch = null;
        other.gameObject.TryGetComponent<FireBall_True>(out FireBall_True A);
        if (A.enabled == true)
        {
            this.HP -= 100;
        }

    }
        public override void Shoot()
    {
        if (Touch != null&&isActive)//&& (Touch.transform.position - transform.position).magnitude <= Range
        {
            if (t > Attack_delay + Attack_time)
            {
                GameObject arrow = Instantiate(Bullet, Bullet.GetComponent<Transform>().position+Vector3.up, Bullet.GetComponent<Transform>().rotation);
                Debug.Log("King_Tower_Shoot_At|"+Touch.name);
                arrow.GetComponent<Shooting_Bullet>().transform_ = Touch.gameObject.transform;
                arrow.GetComponent<Shooting_Bullet>().enabled = true;
                t = 0;
            }
        }

    }
}
