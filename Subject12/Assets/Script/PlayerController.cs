using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 30;
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    PlayerController control;
    public Controller AIcontrol;
    bool possessed = false;

     GameObject cache;
    
    // Use this for initialization
    void Start ()
    {
        control = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
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

        if (cache != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cache.SetActive(true);
                control.enabled = false;
                cache.transform.position = transform.position;
                cache = null;
               
            }
        }
      
    }

    private void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.tag == "AI")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print(Vector3.Distance(transform.position, hitWith.transform.position));
                if (Vector3.Distance(transform.position, hitWith.transform.position) <= 0.5f)
                {
                    AIcontrol.enabled = true;
                    sprite.enabled = false;
                    control.enabled = false;
                    //Control.enabled = true;
                    possessed = true;
                    StartCoroutine(GTFO(hitWith.gameObject));
                   
                }
            }
        }

    }

    IEnumerator GTFO(GameObject player)
    {
        yield return null;
        cache = player;
    }
}
