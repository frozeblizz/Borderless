using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    public static bool isPossessed;
    public static bool isNear;
    public static bool isDead;
    public static bool isDetected;
    public Image gameOver;

	// Use this for initialization
	void Start ()
    {
        gameOver.enabled = false;

        isPossessed = false;
        isNear = false;
        isDetected = false;
	}


    public void GameOver()
    {
        gameOver.enabled = true;
        isDead = true;
    }
}
