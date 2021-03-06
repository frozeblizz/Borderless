﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCon : MonoBehaviour {

   // public int hp = 10;
    //public Sprite DEAD;
    Animator anim;
    public int hp;
    float delayt = 0.3f;
    bool die = false;
    bool onetime = false;

    public AudioClip goreSound;
    public AudioClip hitSound;
    public AudioSource goreSource;
    public AudioSource hitSource;
    public State state;
    public GameObject Dying1;
    public GameObject Dying2;
    public GameObject Q;
    public GameObject Sucksound;
    public int D1;
    public int D2;
    // Use this for initialization
    void Start ()
    {
        state = GameObject.Find("State").GetComponent<State>(); 
        anim = GetComponent<Animator>();
        goreSource.clip = goreSound;
        hitSource.clip = hitSound;
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0 && onetime == false)
        {
            onetime = true;
            Debug.Log("die");
            goreSource.Play();    
            Dead();
            
        }
        if(die)
        {
            delayt -= 1 * Time.deltaTime;
        }
        if (delayt <= 0 && this.gameObject.tag == "Player")
        {
            State.isDead = true;
            
            Debug.Log("player die");
            anim.SetBool("Dead", true);
            state.GameOver();
           

        }
        if (hp <= D1 && die == false)
        {
            Dying1.SetActive(true);
        }
        if (hp <= D2 && die == false)
        {
            Dying2.SetActive(true);
        }
        if (die == true)
        {
            Dying1.SetActive(false);
            Dying2.SetActive(false);
            Q.SetActive(false);
        }

    }
   public void Dead()
    {
        anim.SetBool("Dead", true);
        die = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
        
        transform.Find("Body").gameObject.SetActive(false);
        this.GetComponent<EnemyPatrol>().enabled = false;
        this.GetComponent<Controller>().enabled = false;
        
        if (this.gameObject.layer == 8)
        {
            ScoreBehaviour.scorepoint += 100;
           
        }
        if (this.gameObject.layer == 9)
        {
            ScoreBehaviour.scorepoint += 150;
            
        }
        if (this.gameObject.layer == 10)
        {
            Sucksound.SetActive(false);
            ScoreBehaviour.scorepoint += 200;
            
        }
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    public void decreaseHP()
    {
        if (this.gameObject.layer == 8)
        {
            hp -= 2;
        }
        else
        {
            hp -= 1;
        }
        
        hitSource.Play();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (transform.Find("Body"))
        {
            if (collision.gameObject.tag == "Bullet")
            {
                hp -= 1;
            }
        }

    }
   IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds * Time.deltaTime);
        Time.timeScale = 0;
    }
}
