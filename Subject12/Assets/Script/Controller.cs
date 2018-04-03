using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public static float possessTime = 15;
    public float delayt = 0.3f;
    public float hp = 10;
    public int moveSpeed = 30;
    public int direction;
    private bool onetime = true;
    private bool pos = false;
    
    public PlayerController playerController;
    public Controller Control;
    public shooting shoot;
    
    public GameObject player;
    public GameObject bulletSpawn;
    private GameObject cachePlayer;
    
    public SpriteRenderer sprite;
    public Animator anim;
    public Animator playerAnim;
    private Sprite spritetemp;
    public Sprite Soilder_DEAD;
    public ParticleSystem playerParticle;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        spritetemp = sprite.sprite;
        
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            direction = 0;
            rigid.AddForce(new Vector2(-moveSpeed, 0));
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            sprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            rigid.AddForce(new Vector2(moveSpeed, 0));
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
            Vector3 newScale = player.transform.localScale;
            newScale.x *= -1;
            player.transform.localScale = newScale;
            sprite.flipX = false;
        }
        
        

        if (playerController.cache != null)
        {
            //Debug.Log("not null");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.tag = "AI";
                print("die");
                playerController.cache.SetActive(true);
                Control.enabled = false;
                player.transform.SetParent(null);
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                if (sprite.flipX == false)
                {
                    playerController.cache.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                }
                if (sprite.flipX == true)
                {
                    playerController.cache.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                }
                playerController.cache = null;
                StartCoroutine(delaySprite());
                //playerController.sprite.enabled = true; //ref
                StartCoroutine(getOut());
                this.GetComponent<DeadCon>().Dead();
                bulletSpawn.SetActive(false);
                PlayerController.wanderTime = 5;
                PlayerController.isPossessed = false;
                playerAnim.enabled = true;
                playerParticle.enableEmission = true;
                playerAnim.Play("Ex", -1, 0);
                anim.Play("unPosses", -1, 0);
            }
            if (anim.GetBool("Dead") && pos)
            {
                Time.timeScale = 0;
            }
        }
        if (hp <= 0)
        {
            this.GetComponent<DeadCon>().Dead();
            delayt -= 1 * Time.deltaTime;
            if (delayt <= 0)
            {
                pos = true;
            }
        }
        if (PlayerController.isPossessed == true)
        {
            possessTime -= 1 * Time.deltaTime;
            if (onetime)
            {
                StartCoroutine(Kapip());
                onetime = false;
            }
        }
        if (possessTime <= 0)
        {
            this.GetComponent<DeadCon>().Dead();
            Time.timeScale = 0;
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
            this.GetComponent<DeadCon>().Dead();

            /*delayt -= 1*Time.deltaTime;
            if(delayt <=0)
            {
                pos = true;
                Time.timeScale = 0;
            }
            
            /*hp -= 3 * Time.deltaTime;
            if (hp <= 0)
            {
               
            }*/
        }

    }

    IEnumerator getOut()
    {
        yield return null;
        playerController.control.enabled = true;
    }
    IEnumerator Kapip()
    {
        while (true)
        {
            //yield return new WaitForSeconds(time);
            sprite.sprite = spritetemp;
            yield return new WaitForSeconds(possessTime * Time.deltaTime);
            //  Debug.Log("fuck");
            sprite.sprite = null;
            yield return new WaitForSeconds(possessTime * Time.deltaTime);
        }

    }
    IEnumerator delaySprite()
    {
        yield return new WaitForSeconds(0.15f);
        playerController.sprite.enabled = true;
    }
}
