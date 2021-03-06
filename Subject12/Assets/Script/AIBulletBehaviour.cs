﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBulletBehaviour : MonoBehaviour
{
    public GameObject[] blood;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 1.5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("AI_Hit!!");
                collision.GetComponentInParent<DeadCon>().decreaseHP();
                Instantiate(blood[Random.Range(0, blood.Length)], new Vector2(this.transform.position.x, this.transform.position.y - 0.3f), this.transform.rotation);
                

                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }




}