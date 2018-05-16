using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controller : MonoBehaviour
{
    
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
    public GameObject Q;

    void Start()
    {
        state = GameObject.Find("State").GetComponent<State>();
        anim = GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Soul").GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spritetemp = spriteRenderer.sprite;
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
   
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

        if (Control.enabled)
        {
            Q.SetActive(false);
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

        
        this.GetComponent<DeadCon>().Dead();
        bulletSpawn.SetActive(false);
       
        State.isPossessed = false;
        State.isDetected = true;
        Debug.Log(State.isPossessed);
        playerAnim.enabled = true;
        playerParticle.enableEmission = true;
        playerAnim.Play("Ex", -1, 0);
        Control.enabled = false;
        StartCoroutine(getOut());
        PlayerController.wanderTime = 5;
    }


   

    IEnumerator getOut()
    {
        yield return null;
        playerController.control.enabled = true;
    }
  
    IEnumerator delaySprite()
    {
        yield return new WaitForSeconds(0.15f);
        playerController.spriteRenderer.enabled = true;
    }
}
