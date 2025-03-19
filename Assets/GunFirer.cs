using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunFirer : Alive_Basic
{
    // Start is called before the first frame update
    public GameObject Bullet;
    public float t = 0;
    GameObject HP_t;
    private void Awake()
    {
        HP = 370;
        HP_ = GameObject.Find("HP").gameObject;

        Damage = 113;
        Attack_delay = 1;
        Range = 9;
        Attack_time = 0.7f;
        Set_Tower();
        Alive_Initialize();
        isAlive = true;
        HP_t = Instantiate(HP_, this.gameObject.GetComponent<Transform>().position, HP_.GetComponent<Transform>().rotation,Cav.transform);
        HP_t.GetComponent<Slider>().maxValue = HP;
        HP_t.GetComponent<Slider>().value = HP;
        Cost = 4;
    }
    void Start()
    {
        

    }
    
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        //Search_And_Destory();
        Search_new();
        //Shoot();
        HP_t.transform.position=this.transform.position;
        HP_t.GetComponent<Slider>().value=HP;
        Dead(HP_t);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer&&(other.gameObject.layer==LayerMask.NameToLayer("Enemy")||other.gameObject.layer==LayerMask.NameToLayer("Player"))&&other.gameObject.layer!=LayerMask.NameToLayer("Shoot") )//LayerMask.NameToLayer("Enemy")&& other.gameObject.TryGetComponent<Alive_Basic>(out Alive_Basic d)
        {//&&(other.gameObject.layer==LayerMask.NameToLayer("Enemy")||other.gameObject.layer==LayerMask.NameToLayer("Player"))
            Touch = other.gameObject;
            Debug.Log(gameObject.name+"|"+2);
        }
        else
            Touch = null;
        other.gameObject.TryGetComponent<FireBall_True>(out FireBall_True A);
        if (A.enabled == true && other.gameObject.TryGetComponent<FireBall_True>(out A))
        {
            this.HP -= 100;
        }

    }
    public override void Shoot()
    {
        if (Touch!=null&&(Touch.transform.position-transform.position).magnitude<=Range)
        {
            if (t > Attack_delay + Attack_time)
            {
                GameObject bullet = Instantiate(Bullet, Bullet.GetComponent<Transform>().position, Bullet.GetComponent<Transform>().rotation);
                bullet.GetComponent<Shooting_Bullet>().enabled = true;
                bullet.GetComponent<Shooting_Bullet>().true_layer = gameObject.layer;
                t = 0;
            }
        }

    }

}
