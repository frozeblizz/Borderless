using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeMenu;
	// Use this for initialization
	void Start ()
    {
        upgradeMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(ScoreBehaviour.scorepoint <= 1100 && ScoreBehaviour.scorepoint >= 1000)
        {
            Time.timeScale = 0;
            upgradeMenu.SetActive(true);
            if(ButtonBehaviour.trigger == true)
            {
                upgradeMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}
