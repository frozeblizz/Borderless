using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupMusicVolume : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("music");
        
    }
}
