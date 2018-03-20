using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCon : MonoBehaviour {

   // public int hp = 10;
    //public Sprite DEAD;
    Animator anim;
    int hp = 10;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
    }
   public void Dead()
    {
       anim.SetBool("Dead", true);
        this.GetComponent<BoxCollider2D>().enabled = false;
        transform.Find("Head").gameObject.SetActive(false);
        transform.Find("Body").gameObject.SetActive(false);
    }
    public void HP()
    {
        hp -= 1;
        if(hp <= 0)
        {
            Dead();
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
