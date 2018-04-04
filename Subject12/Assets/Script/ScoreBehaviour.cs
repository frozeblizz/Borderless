using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {
    public Text score;
    public Text mult;
    static public int scorepoint;
    static public float multiplier;

    // Use this for initialization
    void Start ()
    {
        scorepoint = 0;
        multiplier = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        score.text = string.Format("{0:F0}", scorepoint).ToString();
        mult.text = string.Format("{0:F1}", multiplier).ToString();
    }
}
