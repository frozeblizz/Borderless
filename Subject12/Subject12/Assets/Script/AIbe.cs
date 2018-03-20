using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbe : MonoBehaviour {

    public int moveSpeed = 30;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        //rigid.AddForce(new Vector2(-moveSpeed, 0));
        StartCoroutine(AIbeDelay());
    }

    IEnumerator AIbeDelay()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(1);
        rigid.AddForce(new Vector2(-moveSpeed, 0));
        yield return new WaitForSeconds(1);
        moveSpeed += 10;
        rigid.AddForce(new Vector2(moveSpeed, 0));
        moveSpeed += 10;
    }
}
