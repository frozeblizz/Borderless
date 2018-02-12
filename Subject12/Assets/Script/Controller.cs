using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public int moveSpeed = 30;

    private bool controlled;

    public Controller Control;
    private GameObject cachePlayer;

    void Start ()
    {
               
	}
	
	
	void Update ()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2 (-moveSpeed, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(new Vector2(moveSpeed,0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(new Vector2(0, moveSpeed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(new Vector2(0, -moveSpeed));
        }
        
        if (cachePlayer != null)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                cachePlayer.SetActive(true);
                Control.enabled = false;
                cachePlayer.transform.position = transform.position;
                cachePlayer = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D hitWith)
    {
        /*
        if(hitWith.gameObject.tag == "AI" && gameObject.tag =="Player")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.SetActive(false);

            }
        }
        */
        if (hitWith.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print(Vector3.Distance(transform.position, hitWith.transform.position));
                if(Vector3.Distance(transform.position,hitWith.transform.position) <= 0.5f)
                {
                    hitWith.gameObject.SetActive(false);
                    Control.enabled = true;
                    StartCoroutine(GTFO(hitWith.gameObject));
                    //Player = hitWith.gameObject;
                }
            }
        }
            
    }

    IEnumerator GTFO(GameObject player)
    {
        yield return null;
        cachePlayer = player;
    }

}
