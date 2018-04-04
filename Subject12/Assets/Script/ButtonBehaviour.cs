using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

    public static bool trigger;

    // Use this for initialization
    void Start()
    {
        trigger = false;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Clicked(string Upgrade)
    {
        trigger = true;
        if (Upgrade == "Time")
        {
            TimeBehaviour.time += 30;
        }
        if(Upgrade == "Score")
        {
            ScoreBehaviour.multiplier += 0.25f;
        }
        
    }
}
