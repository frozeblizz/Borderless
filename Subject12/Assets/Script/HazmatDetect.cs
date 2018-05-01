using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazmatDetect : MonoBehaviour {

    public static bool detect;
    private Transform player;

	// Use this for initialization
	void Start ()
    {
        detect = true;
        player =  GameObject.FindGameObjectWithTag("Soul").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(detect == true)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
        }
	}
}
