﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public GameObject[] blood;
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
            if(this.gameObject.layer == 8)
            {
                this.GetComponentInParent<Animator>().SetBool("attack", true);
                StartCoroutine(delay());
                Debug.Log("atk");
            }
            if(this.gameObject.layer == 10)
            {
                StartCoroutine(delay());
                Debug.Log("atk");
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (c.direction == 0)
        {
            transform.localScale = new Vector3(-1,1,1);
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

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5 * Time.deltaTime);
        this.GetComponentInParent<Animator>().SetBool("attack", false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Body" && this.GetComponentInParent<Animator>().GetBool("attack"))
        {
            Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);
            ScoreBehaviour.scorepoint += 100;
            collision.GetComponentInParent<DeadCon>().HP();
        }
        if (collision.tag == "Head" && this.GetComponentInParent<Animator>().GetBool("attack"))
        {
            Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);
            ScoreBehaviour.scorepoint += 150;
            collision.GetComponentInParent<DeadCon>().Dead();
        }
    }

}
