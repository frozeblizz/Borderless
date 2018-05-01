using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public static float possessTime = 15;
    public float delayt = 0.3f;
    public int moveSpeed = 30;
    private bool onetime = false;
    private bool pos = false;

    public static bool left;
    public static bool right;

    public PlayerController playerController;
    public Controller Control;
    public Attack shoot;
    
    public GameObject player;
    public GameObject bulletSpawn;
    private GameObject cachePlayer;
    public GameObject gameOver;

    public SpriteRenderer sprite;
    public Animator anim;
    public Animator playerAnim;
    private Sprite spritetemp;
    public Sprite Soilder_DEAD;
    public ParticleSystem playerParticle;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Soul").GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        spritetemp = sprite.sprite;
        
        
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Soul");

    }
    void Update() 
    {

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            right = false;
            left = true;

            rigid.AddForce(new Vector2(-moveSpeed, 0));
           
            if(this.transform.localScale.x > 0)
            {
                 Vector3 newScale = this.transform.localScale;
                 newScale.x *= -1;
                this.transform.localScale = newScale;
            }
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            left = false;
            right = true;
            rigid.AddForce(new Vector2(moveSpeed, 0));
            
            if (this.transform.localScale.x < 0)
            {
                 Vector3 newScale = this.transform.localScale;
                 newScale.x *= -1;
                 this.transform.localScale = newScale;
            }
        }
        if (playerController.cache != null)
        {
            //Debug.Log("not null");
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.tag = "AI";
                print("die");
                playerController.cache.SetActive(true);
                if (this.gameObject.layer == 9)
                {
                    anim.Play("unPosses", -1, 0);
                }
                else if (this.gameObject.layer == 8)
                {
                    anim.Play("DRunPosses", -1, 0);
                }
                else if (this.gameObject.layer == 10)
                {
                    anim.Play("HZunPosses", -1, 0);
                }

                HazmatDetect.detect = true;
                
                player.transform.SetParent(null);
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
               
                playerController.cache = null;
                StartCoroutine(delaySprite());
                
                StartCoroutine(getOut());
                this.GetComponent<DeadCon>().Dead();
                bulletSpawn.SetActive(false);
                PlayerController.wanderTime = 5;
                PlayerController.isPossessed = false;
                playerAnim.enabled = true;
                playerParticle.enableEmission = true;
                playerAnim.Play("Ex", -1, 0);
                Control.enabled = false;
                
            }
           
            if (anim.GetBool("Dead") && pos)
            {
                gameOver.SetActive(true);
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
            gameOver.SetActive(true);
        }
    }


   


    private void OnCollisionStay2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Power")
        {
            this.GetComponent<DeadCon>().Dead();

            
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
