using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : Alive_Basic
{
    // Start is called before the first frame update
    public float t = 0;
    GameObject HP_t;
    private void Awake()
    {
        HP = 500;
        HP_ = GameObject.Find("HP").gameObject;

        Damage = 85;
        Attack_delay = 1;
        Range = 6;
        Attack_time = 0.7f;
        Set_Tower();
        Alive_Initialize();
        isAlive = true;
        HP_t = Instantiate(HP_, this.gameObject.GetComponent<Transform>().position, HP_.GetComponent<Transform>().rotation, Cav.transform);
        HP_t.GetComponent<Slider>().maxValue = HP;
        HP_t.GetComponent<Slider>().value = HP;
        Cost = 3;
    }
    void Start()
    {


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
        if (other.gameObject.layer != gameObject.layer && (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Player")))//LayerMask.NameToLayer("Enemy")&&other.gameObject.TryGetComponent<Alive_Basic>(out Alive_Basic d)
        {//&&(other.gameObject.layer==LayerMask.NameToLayer("Enemy")||other.gameObject.layer==LayerMask.NameToLayer("Player"))
            Touch = other.gameObject;
            Debug.Log(gameObject.name + "|" + 2+"|"+other.name+other.transform.parent.name);
        }
        else
            Touch = null;
        other.gameObject.TryGetComponent<FireBall_True>(out FireBall_True A);
            if (A.enabled==true)
            {
                this.HP -= 100;
            }
        

    }
    public override void Shoot()
    {
        if (Touch != null && (Touch.transform.position - transform.position).magnitude <= Range-4)
        {
            Set_Distance(agent, Touch.transform.position, transform);
            if (t > Attack_delay + Attack_time)
            {
                //GameObject bullet = Instantiate(Bullet, Bullet.GetComponent<Transform>().position, Bullet.GetComponent<Transform>().rotation);
                //bullet.GetComponent<Shooting_Bullet>().enabled = true;
                Ray S = new Ray(transform.position,transform.position-Touch.transform.position);
                Touch.gameObject.GetComponent<Alive_Basic>().HP -= Damage;
                t = 0;
            }
        }

    }

}
