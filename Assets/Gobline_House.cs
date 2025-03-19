using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gobline_House : Alive_Basic
{
    GameObject HP_t;
    public GameObject Gobline_;
    public float t = 0;
    private void Awake()
    {
        Damage = 0;
        Attack_delay = 0;
        Range = 9;
        Attack_time = 2f;
        Alive_Initialize();
        isAlive = true;
        Cost = 5;
        HP_ = GameObject.Find("HP").gameObject;
        HP_t = Instantiate(HP_, this.gameObject.GetComponent<Transform>().position + new Vector3(0, 2, 0), HP_.GetComponent<Transform>().rotation, Cav.transform);
        HP = 700;
        HP_t.GetComponent<Slider>().maxValue = HP;
        HP_t.GetComponent<Slider>().value = HP;
    }
    void Start()
    {

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
            Debug.Log(gameObject.name + "|" + 2);
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
            if (t > Attack_delay + Attack_time)
            {
                GameObject gobline = Instantiate(Gobline_,this.gameObject.transform.Find("Place").transform.position , Gobline_.GetComponent<Transform>().rotation);
                gobline.GetComponent<Gobline>().enabled = true;
                HP -= t * 10;
                t = 0;
            }
        

    }
}
