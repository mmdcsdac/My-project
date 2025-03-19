using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gobline : Alive_Basic
{
    public float t = 0;
    GameObject HP_t;
    private void Awake()
    {
        HP = 200;
        HP_ = GameObject.Find("HP").gameObject;

        Damage = 55;
        Attack_delay = 1;
        Range = 6;
        Attack_time = 0.7f;
        Set_Tower();
        Alive_Initialize();
        isAlive = true;
        HP_t = Instantiate(HP_, this.gameObject.GetComponent<Transform>().position, HP_.GetComponent<Transform>().rotation, Cav.transform);
        HP_t.GetComponent<Slider>().maxValue = HP;
        HP_t.GetComponent<Slider>().value = HP;

    }
    void Start()
    {
        Cost = 4;

    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        //Search_And_Destory();
        Search_And_Destory();
        Shoot();
        HP_t.transform.position = this.transform.position;
        HP_t.GetComponent<Slider>().value = HP;
        Dead(HP_t);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer && (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Player")) )//LayerMask.NameToLayer("Enemy")&& other.gameObject.TryGetComponent<Alive_Basic>(out Alive_Basic d)
        {//&&(other.gameObject.layer==LayerMask.NameToLayer("Enemy")||other.gameObject.layer==LayerMask.NameToLayer("Player"))
            Touch = other.gameObject;
            Debug.Log(gameObject.name + "|" + 2);
        }
        else
            Touch = null;
        if (other.gameObject.TryGetComponent<FireBall_True>(out FireBall_True A))
        {
            this.HP -= 100;
        }

    }
    public override void Shoot()
    {
        if (Touch != null && (Touch.transform.position - transform.position).magnitude <= Range)
        {
            if (t > Attack_delay + Attack_time)
            {
                Ray S = new Ray(transform.position, transform.position - Touch.transform.position);
                Touch.gameObject.GetComponent<Alive_Basic>().HP -= Damage;
                t = 0;
            }
        }

    }
}
