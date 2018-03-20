using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D rigid;
    Controller c;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        c = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c.direction == 1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (c.direction == 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (c.direction == 2)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (c.direction == 3)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
       
        //Destroy(gameObject, 2.0f);
    }

   
}