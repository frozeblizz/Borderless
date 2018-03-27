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
    }

}
