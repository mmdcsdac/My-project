using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class Alive_Basic : Basic
{
    // Start is called before the first frame update
    public GameObject Cav;
    public Transform transform;
    public NavMeshAgent agent;
    public Collider Search;
    Vector3 target = new Vector3(-4.21000004f, -0.127932072f, 7.78999996f);
    Vector3 Tower_Left_enemy = new Vector3(-3.44000006f, -2.55999994f, 12.29f);
    Vector3 Tower_Right_enemy = new Vector3(7.11000013f, -2.55999994f, 12.3100004f);
    Vector3 Tower_Left_Player = new Vector3(-3.44000006f, -2.55999994f, -5.59000015f);
    Vector3 Tower_Right_Player = new Vector3(7.03999996f, -2.55999994f, -5.59000015f);
    public float HP;
    public float speed;
    public float Damage;
    public float Attack_time;
    public float Attack_delay;
    public LayerMask isPlayer;
    public float Range;
    public bool ishaveTarget;
    public bool isTargetStill;
    public GameObject Touch;
    public Alive_Basic Alive;
    Ray ray;
    RaycastHit hit;
    public int Cost;
    public GameObject HP_;
    public float t_P = 0;
    public GameObject C;
    public virtual void Shoot() { }
    private void Awake()
    {
        Touch = new GameObject();
        Touch = null;
        //GetComponent<LayerMask>().layer = LayerMask.NameToLayer(isPlayer);
        isAlive = true;
        
    }
    void Start()
    {
       ishaveTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ray.direction = Quaternion.AngleAxis(10f, transform.up) * ray.direction;
        //Set_Distance(agent, target,transform);
        //hit = Scan(ray);
        //Searching_Target(transform, Range,ray);
        //Search_And_Destory();
        //Set_Target(agent, hit.transform.position, transform); 
    }

    public void Alive_Initialize()
    {
        isTargetStill = true;
        agent = GetComponent<NavMeshAgent>();
        Range = 2f;
        transform = GetComponent<Transform>();
        ray = new Ray(transform.position, transform.forward * Range*3);//
        //agent.stoppingDistance = Range;
        Search = GetComponentInChildren<MeshCollider>();
        Cav = GameObject.Find("Canvas");
        
        //Search.gameObject.GetComponent<Transform>().localScale = new Vector3(Range, 0.1f, Range);
    }
    public void Search_And_Destory()
    {
        t_P += Time.deltaTime;
        Debug.Log(ishaveTarget + "|" + gameObject.name);
        if (ishaveTarget)
        {
            if(t_P>=5)
            {
                Scan();
                t_P = 0;
            }
            To_Attack();
        }
        else
        {
            Scan();
            t_P = 0;
            if (ishaveTarget)
            {
                //Debug.Log(ishaveTarget);
                To_Attack();
            }
        }
        //for (int i = 0; i < 2; i++)
        //{
        //    for (int j = 0; j < C.GetComponent<Map_Initialize>().Towers[i].Count; j++)
        //    {
        //        if (C.GetComponent<Map_Initialize>().Towers[i][j].layer != gameObject.layer && (C.GetComponent<Map_Initialize>().Towers[i][j].transform.position - gameObject.transform.position).magnitude <= Range)
        //        {
        //            agent.isStopped = true;
        //        }
        //    }

        //}
    }
    public void To_Attack()
    {

        if (Touch == null)
        {
            Set_Tower();
            ishaveTarget=false; 
        }
            
        else if(Touch != null)
        {
            
            if ((Alive.gameObject.transform.position - transform.position).magnitude <= Range)
            {
                //Debug.Log(1);
                Set_Distance(agent, transform.position, transform);
                transform.LookAt(Alive.gameObject.transform.position);
            }
            else
            {
                Set_Distance(agent,Alive.gameObject.transform.position, transform);
            }
            ishaveTarget = true;
            if (Touch==null)
                ishaveTarget = false;
        }

    }
    public void Set_Distance(NavMeshAgent agent,Vector3 target,Transform transform)
    {
        if ((transform.position-target).magnitude>=Range)
            agent.SetDestination(target);
        else
        {
            agent.SetDestination(transform.position);
            transform.LookAt(target);
        }

    }
    public void Set_Tower()
    {
        if (transform.position.x <= 1.88f && gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            agent.SetDestination(Tower_Left_enemy);
            this.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else if (transform.position.x > 1.88f && gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            agent.SetDestination(Tower_Right_enemy);
            this.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else if (transform.position.x <= 1.88f && gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            agent.SetDestination(Tower_Left_Player);
            this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
        else
        {
            agent.SetDestination(Tower_Right_Player);
            this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }
    public void Set_Target(NavMeshAgent agent, Vector3 target, Transform transform)
    {
        To_Attack();
    }

    public RaycastHit Scan()
    {
        ray.direction= Quaternion.AngleAxis(5f,transform.up) * ray.direction;
        if (Touch!=null||true)//a||
        {
            
            bool b;
            if (Touch != null)
            {
                b = Touch.transform.TryGetComponent<Alive_Basic>(out Alive);//hit.collider.TryGetComponent<Alive_Basic>(out Alive)||
                Debug.Log(Touch.transform.name+10);
                if (b)
                {
                    //Debug.Log(Alive.gameObject.name +"|"+ Alive.gameObject.layer+"|"+LayerMask.NameToLayer("Enemy")+"|"+gameObject.name);
                    if (Alive.gameObject.layer != gameObject.layer)
                    {
                        //Debug.Log(b + "|" + hit.collider.name + "|" + gameObject.name);
                        ishaveTarget = true;
                        // 
                    }
                }
                else
                {
                    Alive=null; 
                }
            }
        }
            //ishaveTarget = true;  
        return hit;
    }
    public void Dead(GameObject HP_t)
    {
        if (HP <= 0)
        {
            Destroy(HP_t);
            for (int i = 0; i < Map_Initialize.Player_Soliders.Count; i++)
            {
                if (Map_Initialize.Player_Soliders[i]==this.gameObject)
                {
                    Map_Initialize.Player_Soliders.RemoveAt(i);
                }
            }
            Destroy(this.gameObject);
        }
        
    }
    public void Search_new()

    {
        Set_Tower();
        if (Touch!=null)
        {
            agent.SetDestination(Touch.transform.position);
            if ((Touch.transform.position - transform.position).magnitude <= Range)
            {
                agent.SetDestination(gameObject.transform.position);
                gameObject.transform.LookAt(Touch.transform.position);
                Shoot();
            }
        }
        else
        {
            return;
        }
    }
    public void Attack_T()
    {

    }
}
