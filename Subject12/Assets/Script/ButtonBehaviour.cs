using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void Clicked(string Scene)
    {
    
        if(Scene == "Prototype")
        {
            SceneManager.LoadScene("Prototype");
        }
        if(Scene == "Quit")
        {
            Application.Quit();
        }
    }
}
