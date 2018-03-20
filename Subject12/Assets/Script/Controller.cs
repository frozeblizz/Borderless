using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int moveSpeed = 30;
    public int hp = 10;
    public Controller Control;
    public shooting shoot;
    public Sprite Soilder_DEAD;
    private bool pos = false;
    public Animator anim;
    public int direction;
    public PlayerController playerController;
    public GameObject bulletSpawn;

    private GameObject cachePlayer;
    

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
            anim.SetBool("Left",true);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            rigid.AddForce(new Vector2(moveSpeed,0));
            anim.SetBool("Right",true);
            anim.SetBool("Left", false);
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = 2;
            rigid.AddForce(new Vector2(0, moveSpeed));
            anim.SetBool("Up",true);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Down", false);


        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = 3;
            rigid.AddForce(new Vector2(0, -moveSpeed));
            anim.SetBool("Down",true);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
            anim.SetBool("Up", false);
        }
        
        if (playerController.cache != null)
        {
            //Debug.Log("not null");
            if(Input.GetKeyDown(KeyCode.E))
            {
                playerController.cache.SetActive(true);
                Control.enabled = false;
                
                playerController.cache.transform.position = transform.position;
                playerController.cache = null;
                playerController.sprite.enabled = true;
                playerController.control.enabled = true;
                pos = false;
                anim.Play("Dead");
                bulletSpawn.SetActive(false);
            }
        }
        if (hp <= 0)
        {
            anim.Play("Dead");
        }
    }


    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet" && pos == false)
        {
            hp -= 1;
        }
    }

    //IEnumerator GTFO(GameObject player)
    //{
    //    yield return null;
    //    cachePlayer = player;
    //}

}
