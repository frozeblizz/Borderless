using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 30;
    public static bool isPossessed = false; //check if possessed
    public static float wanderTime = 5; //time before player die

    private Rigidbody2D rigid;
    public SpriteRenderer sprite;
    public PlayerController control;
    public shooting shoot;
    private DeadCon deadCon;
    public GameObject cache;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        deadCon = GetComponent<DeadCon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(new Vector2(-moveSpeed, 0));

        }
        if (Input.GetKey(KeyCode.D))
        {

            rigid.AddForce(new Vector2(moveSpeed, 0));

        }
        if (Input.GetKey(KeyCode.W))
        {

            rigid.AddForce(new Vector2(0, moveSpeed));

        }
        if (Input.GetKey(KeyCode.S))
        {

            rigid.AddForce(new Vector2(0, -moveSpeed));

        }

        print(cache);
        if(isPossessed == false)
        {
            wanderTime -= 1 * Time.deltaTime;
        }
        //if don't possess within time the player will die
        if(wanderTime <= 0)
        {
            
            Time.timeScale = 0;
        }
    }
    
    private void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.tag == "AI")
        {
            if (control.enabled == false) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                print(Vector3.Distance(transform.position, hitWith.transform.position));
                if (Vector3.Distance(transform.position, hitWith.transform.position) <= 0.5f)
                {
                    isPossessed = true;
                    hitWith.gameObject.GetComponent<Controller>().enabled = true;
                    hitWith.gameObject.GetComponentInChildren<shooting>().enabled = true;
                    sprite.enabled = false;
                    player.transform.SetParent(hitWith.transform);
                    control.enabled = false;
                    player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    StartCoroutine(GTFO(gameObject));
                    Controller.possessTime = 20;
                }
            }
        }

    }

    IEnumerator GTFO(GameObject player)
    {
        yield return null;
        cache = player;
    }
}
