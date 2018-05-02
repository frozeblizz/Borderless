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
		if(detect == true)
        {
            if (Vector2.Distance(player.position, this.transform.position) < range)
            {
                if(player.position.x < this.transform.position.x)
                {
                    this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0 * Time.deltaTime);
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
                }
                else
                {
                    this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0 * Time.deltaTime);
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
                }
                
            }
            else
            {
                this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime); 
            }
            
        }
        if (player.position.x < transform.position.x && this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
           
        }
        else if (player.position.x >= transform.position.x && this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Soul"&&PlayerController.isPossessed == false)
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
