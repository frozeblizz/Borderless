using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    public static bool trigger;
    public Text Credits;
    // Use this for initialization
    void Start()
    {
        trigger = false;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnClicked(string Scene)
    {
    
        if(Scene == "Game")
        {
            State.isDead = false;
            State.isPossessed = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
        if(Scene == "Exit")
        {
            Application.Quit();
        }
        if(Scene == "Main")
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }

  
}
