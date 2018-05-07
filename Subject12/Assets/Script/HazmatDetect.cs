using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazmatDetect : MonoBehaviour {

    public static bool detect;
    private Transform player;
    public int range;
    public GameObject Player;
    public GameObject gameOver;
	// Use this for initialization
	void Start ()
    {
        gameOver.SetActive(false);
        detect = true;
        player =  GameObject.FindGameObjectWithTag("Soul").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Soul" && State.isPossessed == false)
            {
                Destroy(collision.gameObject);
                Time.timeScale = 0;
                Debug.Log("HZHit!!");
                StartCoroutine(waitOneFrame());
                gameOver.SetActive(true);
            }
        }
    }
    IEnumerator waitOneFrame()
    {
        yield return null;

    }
}
