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
    private bool onetime = false;
    private bool pos = false;
    public static bool confuse = false;

    public PlayerController playerController;
    public Controller Control;
    public shooting shoot;
    
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
            direction = 0;
            rigid.AddForce(new Vector2(-moveSpeed, 0));
           /* anim.SetBool("Left", true); //set left animation to true
            anim.SetBool("Right", false);//set right animation to false*/
            //sprite.flipX = true;
            if(this.transform.localScale.x > 0)
            {
                 Vector3 newScale = this.transform.localScale;
                 newScale.x *= -1;
                this.transform.localScale = newScale;
            }
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            rigid.AddForce(new Vector2(moveSpeed, 0));
            /*   anim.SetBool("Right", true);
               anim.SetBool("Posses", false);
               anim.SetBool("Left", false);*/
            //  sprite.flipX = false;
            /*if (this.GetComponent<EnemyPatrol>().isleftnaja == true)
            {
                this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                this.GetComponent<EnemyPatrol>().isleftnaja = false;
            }*/
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
                Control.enabled = false;
                player.transform.SetParent(null);
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
               /* if (sprite.flipX == false)
                {
                    playerController.cache.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                }
                if (sprite.flipX == true)
                {
                    playerController.cache.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                }*/
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
                anim.SetBool("unPosses", true);
                confuse = true;
            }
            if (confuse == true)
            {
                if (this.gameObject.layer == 10)
                {
                    rigid.velocity = new Vector2(2, 0);
                }
                else
                {
                    Debug.Log("confuse");
                    rigid.velocity = new Vector2(0, 0);
                }
                

            }
            if (anim.GetBool("Dead") && pos)
            {
                gameOver.SetActive(true);
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
            gameOver.SetActive(true);
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
