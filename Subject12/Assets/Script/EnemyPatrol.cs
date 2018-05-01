using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float stop;
    private float near;
    private Transform target;
    public bool isleftnaja = false;
    //public Sprite right;
    public GameObject bulletSpawn;
    public Rigidbody2D projectile;
    public int shootingRange;
    bool delay = false;
    float delaytime = 1;
   
    // Use this for initialization
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Soul");
        near = 5;
        stop = 5;
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (Vector2.Distance(transform.position, target.position) < near)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            
        }
        else if(Vector2.Distance(transform.position, target.position) > stop)
        { 
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,-2.1f), target.position, speed * Time.deltaTime);
            
        }
        else if(Vector2.Distance(transform.position, target.position) < stop && Vector2.Distance(transform.position, target.position) > near)
        {
            transform.position = this.transform.position;
        }
        if (Vector2.Distance(transform.position, target.position) < shootingRange)
        {
            if (this.gameObject.layer == 9 && !delay)
            {
                Rigidbody2D instantiatedProjectile = Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as
                Rigidbody2D;
                if(target.transform.position.x < this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(-20 , 0);
                }
                else if (target.transform.position.x > this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(20 , 0);
                }

                


                delaytime = 1;
                delay = true;
            }
        }
        if(delay)
        {
            delaytime -= Time.deltaTime;
            if(delaytime <=0)
            {
                delay = false;
            }
        }
        if (target.position.x < transform.position.x && this.transform.localScale.x > 0)
        { 
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            isleftnaja = true;
        }
        else if (target.position.x >= transform.position.x &&this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            isleftnaja = false;
        }

        
    }

}
