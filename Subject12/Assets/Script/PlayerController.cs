﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 30;
    public static float wanderTime = 5;
    public static bool isPossessed = false;
    private Rigidbody2D rigid;
    public SpriteRenderer sprite;
    public PlayerController control;
    public shooting shoot;

    public GameObject cache;
    public GameObject player;
    public Sprite spritetemp;
    bool onetime = true;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
       // spritetemp = sprite.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-moveSpeed, 0));

        }
        if (Input.GetKey(KeyCode.D))
        {

            rigid.AddForce(new Vector2(moveSpeed, 0));

        }
        if (Input.GetKey(KeyCode.W))
        {

            rigid.AddForce(new Vector2(0, moveSpeed));

        }
        if (Input.GetKey(KeyCode.S))
        {

            rigid.AddForce(new Vector2(0, -moveSpeed));

        }
        

       // print(cache);
        if (isPossessed == false)
       {
            //sprite.sprite = spritetemp;
            wanderTime -= 1 * Time.deltaTime;
            if(onetime)
            {
                StartCoroutine(Kapip());
                onetime = false;
            }
            
        }
       if(wanderTime <= 0)
       {
            Destroy(gameObject);
           Time.timeScale = 0;
       }
    }

    private void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.tag == "AI")
        {
            if (control.enabled == false) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                print(Vector3.Distance(transform.position, hitWith.transform.position));
                if (Vector3.Distance(transform.position, hitWith.transform.position) <= 0.5f)
                {
                    isPossessed = true;
                    hitWith.gameObject.GetComponent<Controller>().enabled = true;
                   
                    hitWith.gameObject.GetComponentInChildren<shooting>().enabled = true;
                    sprite.enabled = false;

                    player.transform.SetParent(hitWith.transform);
                    control.enabled = false;
                    player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    
                    StartCoroutine(GTFO(gameObject));
                    Controller.possessTime = 15;
                    hitWith.gameObject.GetComponent<EnemyPatrol>().enabled = false;
                }
                hitWith.gameObject.tag = "Player";

            }
            
        }

    }

    IEnumerator GTFO(GameObject player)
    {
        yield return null;
        cache = player;
    }

    IEnumerator Kapip()
    {
        while(true)
        {
            //yield return new WaitForSeconds(time);
            sprite.sprite = spritetemp;
            yield return new WaitForSeconds(wanderTime*Time.deltaTime*7);
          //  Debug.Log("fuck");
            sprite.sprite = null;
            yield return new WaitForSeconds(wanderTime * Time.deltaTime*7);

        }

        
    }
}
