using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour {
    public Text score;
    static public int scorepoint;
    // Use this for initialization
    void Start () {
        scorepoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = string.Format("{0:F0}", scorepoint).ToString();
    }
}
