using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int moveSpeed = 30;
    public float hp = 10;
    public Controller Control;
    public shooting shoot;
    public Sprite Soilder_DEAD;
    private bool pos = false;
    public Animator anim;
    public int direction;
    public PlayerController playerController;
    public GameObject bulletSpawn;
    float delayt = 0.3f;

    private GameObject cachePlayer;
    

    public float gethp()
    {
        return hp;
    }

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	
	void Update ()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        
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
                anim.SetBool("Dead",true);
                bulletSpawn.SetActive(false);
            }
            if(anim.GetBool("Dead")&&pos )
            {
                Time.timeScale = 0;
            }
        }
        if (hp <= 0)
        {
            anim.SetBool("Dead",true);
        }
    }


    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet")
        {
            hp -= 1;
        }
        
    }

    private void OnCollisionStay2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Power")
        {
            anim.SetBool("Dead", true);
            
            delayt -= 1*Time.deltaTime;
            if(delayt <=0)
            {
                pos = true;
            }
            
            /*hp -= 3 * Time.deltaTime;
            if (hp <= 0)
            {
               
            }*/
        }
        
    }

    //IEnumerator GTFO(GameObject player)
    //{
    //    yield return null;
    //    cachePlayer = player;
    //}

}
