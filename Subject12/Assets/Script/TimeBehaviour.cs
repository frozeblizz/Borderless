﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBehaviour : MonoBehaviour {

    float time;
    public Text text;
	// Use this for initialization
	void Start ()
    {
        time = 100;
        
	}

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0:F0}", time).ToString();
        time -= 1 * Time.deltaTime;
        if ( time <= 0 )
        {
            Time.timeScale = 0;
        }
	}
}
