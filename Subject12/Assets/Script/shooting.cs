using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

	public Rigidbody2D projectile;
    public float speed = 20;
    public float fireRate;
    private float nextFire;
    public GameObject Controller;
    Controller c;
    public GameObject bulletSpawn;
    Rigidbody2D instantiatedProjectile;

    void Start()
    {
        c = GetComponentInParent<Controller>();
        bulletSpawn = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (this.gameObject.layer == 9)
            {
                instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as
                Rigidbody2D;
            }

            if (c.direction == 1)
            {
                Debug.Log("Right");
                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
                //transform.localPosition = new Vector3(0.75f, 0, 0);
            }
            if (c.direction == 0)
            {
                Debug.Log("Left");
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(-speed, 0, 0));
                //transform.localPosition = new Vector3(-0.75f, 0, 0);
            }
            if (c.direction == 2)
            {
                Debug.Log("Up");
                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
                //transform.localPosition = new Vector3(0, 0.75f, 0);
            }
            if (c.direction == 3)
            {
                Debug.Log("Down");
                    instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, -speed, 0));
                //transform.localPosition = new Vector3(0, -0.75f, 0);
            }

        }

        if (c.direction == 1)
        {
            transform.localPosition = new Vector3(0.75f, 0, 0);
        }
        if (c.direction == 0)
        {
            transform.localPosition = new Vector3(-0.75f, 0, 0);
        }
        if (c.direction == 2)
        {
            transform.localPosition = new Vector3(0, 1.5f, 0);
        }
        if (c.direction == 3)
        {
            transform.localPosition = new Vector3(0, -1.5f, 0);
        }
    }
}
