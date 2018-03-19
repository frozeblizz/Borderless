using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public int moveSpeed = 30;
    public int hp = 10;
    public Controller Control;
    public shooting shoot;
    public Sprite Soilder_DEAD;
    private bool pos = false;
    public Animator anim;
    public int direction;

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
        anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.A))
        {
            direction = 0;
            rigid.AddForce(new Vector2 (-moveSpeed, 0));
            anim.Play("Left");

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            rigid.AddForce(new Vector2(moveSpeed,0));
            anim.Play("Right");
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = 2;
            rigid.AddForce(new Vector2(0, moveSpeed));
            anim.Play("Up");
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = 3;
            rigid.AddForce(new Vector2(0, -moveSpeed));
            anim.Play("Down");
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
                anim.Play("Dead");
            }
        }
        if (hp <= 0)
        {
            anim.Play("Dead");
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
