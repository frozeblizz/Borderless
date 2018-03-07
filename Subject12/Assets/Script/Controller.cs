using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public int moveSpeed = 30;
    //public int hp = 10;
    public Controller Control;
    public shooting shoot;
    public Sprite Soilder_DEAD;
    private bool pos = false;

    private GameObject cachePlayer;
    public GameObject AI;

    public float gethp()
    {
        return hp;
    }

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
            if(Input.GetKeyDown(KeyCode.E))
            {
                cachePlayer.SetActive(true);
                Control.enabled = false;
                shoot.enabled = false;
                cachePlayer.transform.position = transform.position;
                cachePlayer = null;
                pos = false;
                this.GetComponent<SpriteRenderer>().sprite = Soilder_DEAD;
            }
        }
        if (hp <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Soilder_DEAD;
        }
    }

    private void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print(Vector3.Distance(transform.position, hitWith.transform.position));
                if(Vector3.Distance(transform.position,hitWith.transform.position) <= 0.5f)
                {
                    hitWith.gameObject.SetActive(false);
                    Control.enabled = true;
                    shoot.enabled = true;
                    StartCoroutine(GTFO(hitWith.gameObject));
                    pos = true;
                }
            }
        }
            
    }

    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet" && pos == false)
        {
            hp -= 1;
        }
    }

    IEnumerator GTFO(GameObject player)
    {
        yield return null;
        cachePlayer = player;
    }

}
