using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeMenu;
    public static bool isTrigger;
	// Use this for initialization
	void Start ()
    {
        isTrigger = false;
        upgradeMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(ScoreBehaviour.scorepoint >= 1500 && isTrigger == false)
        {
            
            upgradeMenu.SetActive(true);

            if(Input.GetKey(KeyCode.U))
            {
                isTrigger = true;
                TimeBehaviour.time += 30;
            }
            if (Input.GetKey(KeyCode.I))
            {
                isTrigger = true;
                //Critical chance
            }
            if (Input.GetKey(KeyCode.O))
            {
                isTrigger = true;
                ScoreBehaviour.multiplier += 0.1f;
            }
            if (ButtonBehaviour.trigger == true)
            {
                upgradeMenu.SetActive(false);
                
            }
        }
        if (isTrigger == true)
        {
            upgradeMenu.SetActive(false);

        }
    }
}
