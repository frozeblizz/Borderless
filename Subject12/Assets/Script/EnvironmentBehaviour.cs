using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBehaviour : MonoBehaviour {
    int damage = 1;
    public Controller control;

	// Use this for initialization
	void Start ()
    {
        control = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    private void OnCollisionEnter2D(Collision2D hitWith)
    {
        if (hitWith.gameObject.tag == "AI")
        {
            control.hp -= damage;
        }
    }
}
