using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCon : MonoBehaviour {

   // public int hp = 10;
    //public Sprite DEAD;
    Animator anim;
    public int hp;
    float delayt = 0.3f;
    bool die = false;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hp <= 0)
        {
            hp = -1;
            Debug.Log("die");
            Dead();
            if(this.gameObject.layer == 8)
            {
                ScoreBehaviour.scorepoint += 100;
            }
            if (this.gameObject.layer == 9)
            {
                ScoreBehaviour.scorepoint += 150;
            }
            if (this.gameObject.layer == 10)
            {
                HazmatDetect.detect = false;
                ScoreBehaviour.scorepoint += 200;
            }
        }
        if(die)
        {
            delayt -= 1 * Time.deltaTime;
        }
        if (delayt <= 0 && this.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
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
        
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    public void decreaseHP()
    {
        hp -= 1;
        if(hp <= 0)
        {
            Dead();
        }
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
    /*private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet")
        {
            hp -= 1;
        }
    }*/
}
