using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    public GameObject Player;
	// Use this for initialization
	void Start ()
    {
        
        Instantiate(Player, transform.position, transform.rotation);
    }

}
