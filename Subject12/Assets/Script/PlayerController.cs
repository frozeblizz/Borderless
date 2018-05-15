using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int moveSpeed;
    public static float wanderTime;
    public Animator anim;
    public ParticleSystem particle;
    public AudioClip PossesAudio;
    public AudioSource audioSource;

    private Rigidbody2D rigid;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;

    [HideInInspector]
    public PlayerController control;


   
    public GameObject cache;

    [HideInInspector]
    public Sprite spritetemp;


    public GameObject player;
    public State state;
    bool onetime = true;
    // Use this for initialization
    void Start()
    {
        control = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();
        state = GameObject.Find("State").GetComponent<State>();
        wanderTime = 5;
        moveSpeed = 30;
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



        // print(cache);
        if (State.isPossessed == false)
        {
            //sprite.sprite = spritetemp;
            wanderTime -= 1 * Time.deltaTime;
            if (onetime)
            {
                StartCoroutine(Kapip());
                onetime = false;
            }

        }
        if (wanderTime <= 0)
        {
            gameObject.SetActive(false);
            state.GameOver();
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D hitWith)
    {
        if (hitWith.gameObject.tag == "AI" && State.isPossessed == false)
        {
            if (control.enabled == false) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                //print(Vector3.Distance(transform.position, hitWith.transform.position));
                if (Vector3.Distance(transform.position, hitWith.transform.position) <= 0.5f)
                {
                    State.isDetected = false;
                    State.isPossessed = true;
                    Debug.Log(State.isPossessed);
                    hitWith.gameObject.GetComponent<Controller>().enabled = true;
                    hitWith.gameObject.GetComponentInChildren<Attack>().enabled = true;
                    spriteRenderer.enabled = false;

                    player.transform.SetParent(hitWith.transform);
                    Vector3 pos = player.transform.localPosition;
                    pos.x = 0;
                    player.transform.localPosition = pos;
                    control.enabled = false;
                    player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    rigid.velocity = Vector2.zero;

                    StartCoroutine(Possess(this.gameObject));
                    Controller.possessTime = 15;
                    hitWith.gameObject.GetComponent<EnemyPatrol>().enabled = false;
                    if (hitWith.gameObject.layer == 9)
                    {
                        hitWith.gameObject.GetComponent<Animator>().SetBool("Posses", true);
                    }
                    else if (hitWith.gameObject.layer == 8)
                    {
                        hitWith.gameObject.GetComponent<Animator>().Play("DRPosses", -1, 0);
                    }
                    else if (hitWith.gameObject.layer == 10)
                    {
                        hitWith.gameObject.GetComponent<Animator>().Play("HZPosses", -1, 0);
                    }
                    //hitWith.gameObject.GetComponent<Animator>().SetBool("Posses", false);
                    anim.enabled = false;
                    particle.enableEmission = false;
                }
                hitWith.gameObject.tag = "Player";


            }

        }

    }
    
    IEnumerator Possess(GameObject player)
    {
        yield return null;
        cache = player;
        Debug.Log(cache);
    }

    IEnumerator Kapip()
    {
        while(true)
        {
            //yield return new WaitForSeconds(time);
            //sprite.sprite = spritetemp;
            yield return new WaitForSeconds(wanderTime*Time.deltaTime*6);
          //  Debug.Log("fuck");
            //sprite.sprite = null;
            yield return new WaitForSeconds(wanderTime * Time.deltaTime*6);

        }

        
    }
}
