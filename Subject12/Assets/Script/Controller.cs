using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int moveSpeed = 30;
    public int hp = 10;
    public int direction;
    public Controller Control;
    public shooting shoot;
    public Sprite Soilder_DEAD;
    public Animator anim;
    public PlayerController playerController;
    
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
        
        if (playerController.cache != null)
        {
            Debug.Log("not null");
            if(Input.GetKeyDown(KeyCode.E))
            {
                playerController.cache.SetActive(true);
                Control.enabled = false;
                playerController.cache = null;
                playerController.sprite.enabled = true;
                playerController.control.enabled = true;
                anim.Play("Dead");
                playerController.shoot.enabled = false;
            }
        }
        if (hp <= 0)
        {
            anim.Play("Dead");
        }
    }


    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet")
        {
            hp -= 1;
        }
        if (hitWith.gameObject.tag == "Electric")
        {
            hp -= 10;
        }
    }

    
}