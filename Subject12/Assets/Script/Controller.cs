using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controller : MonoBehaviour
{
    public static float possessTime = 15;
    public float delayt = 0.3f;
    public int moveSpeed = 30;


    private bool onetime = false;

    public static bool left;
    public static bool right;

    public PlayerController playerController;
    public Controller Control;
    
    
    public GameObject player;
    public GameObject bulletSpawn;

    public State state;
   

    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public Animator playerAnim;
    private Sprite spritetemp;
    
    public ParticleSystem playerParticle;

    void Start()
    {
        state = GameObject.Find("State").GetComponent<State>();
        anim = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Soul").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spritetemp = spriteRenderer.sprite;
             
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
             anim.SetBool("Walk", true);
            if (this.transform.localScale.x > 0)
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
            anim.SetBool("Walk", true);
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
                print("die");
                unPosses();             

 
            }
           
            if (anim.GetBool("Dead") && State.isPossessed == true)
            {
                state.GameOver();
            }
        }
        
        if (State.isPossessed == true)
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
            state.GameOver();
        }
    }


   private void unPosses()
    {
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
        this.gameObject.tag = "AI";
        playerController.cache.SetActive(true);
        player.transform.SetParent(null);
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        playerController.cache = null;
        StartCoroutine(delaySprite());

        StartCoroutine(getOut());
        this.GetComponent<DeadCon>().Dead();
        bulletSpawn.SetActive(false);
        PlayerController.wanderTime = 5;
        State.isPossessed = false;
        State.isDetected = true;
        playerAnim.enabled = true;
        playerParticle.enableEmission = true;
        playerAnim.Play("Ex", -1, 0);
        Control.enabled = false;
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
            spriteRenderer.sprite = spritetemp;
            yield return new WaitForSeconds(possessTime * Time.deltaTime);
            //  Debug.Log("fuck");
            spriteRenderer.sprite = null;
            yield return new WaitForSeconds(possessTime * Time.deltaTime);
        }

    }
    IEnumerator delaySprite()
    {
        yield return new WaitForSeconds(0.15f);
        playerController.spriteRenderer.enabled = true;
    }
}
