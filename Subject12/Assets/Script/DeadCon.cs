using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCon : MonoBehaviour {

    public int hp = 10;
    public Sprite Soilder_DEAD;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (hp <= 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Soilder_DEAD;
        }
    }

    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "Bullet")
        {
            hp -= 1;
        }
    }
}
