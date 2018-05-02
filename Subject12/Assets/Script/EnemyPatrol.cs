using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   
    public float speed;
    private float stop;
    private float near;
    private Transform target;
    private Transform player;
    public bool isleftnaja = false;
    //public Sprite right;
    public GameObject bulletSpawn;
    public Rigidbody2D projectile;
    public Rigidbody2D soul;
    public int shootingRange;
    bool delay = false;
    float delaytime = 1;
   
    // Use this for initialization
    void Start()
    {
        soul = GameObject.FindGameObjectWithTag("Soul").GetComponent<Rigidbody2D>();

        near = 5;
        stop = 5;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Soul").GetComponent<Transform>();
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
                if (target.transform.position.x < this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(-20, 0);
                }
                else if (target.transform.position.x > this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(20, 0);
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
