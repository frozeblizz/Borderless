using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public float stop;
    public float near;
    private Transform target;
    public Sprite left;
    public Sprite right;
    public GameObject bulletSpawn;
    public Rigidbody2D projectile;
    public int shootingRange;
    bool delay = false;
    float delaytime = 1;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < near)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            this.GetComponent<SpriteRenderer>().sprite = left;
        }
        else if(Vector2.Distance(transform.position, target.position) > stop)
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            this.GetComponent<SpriteRenderer>().sprite = right;
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
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(speed*3, 0, 0));
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
    }

}
