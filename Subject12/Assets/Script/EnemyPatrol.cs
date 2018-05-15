using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    private float stop;
    private float near;
    private Transform target;
    private Transform player;
    public bool isleftnaja = false;
    //public Sprite right;
    public GameObject bulletSpawn;
    public Rigidbody2D projectile;
    public State state;
    public AudioClip suckSound;
    public AudioSource suckSource;

    public int shootingRange;
    public int hazmatRange;
    bool delay = false;
    float delaytime = 1;

    // Use this for initialization
    void Start()
    {
        state = GameObject.Find("State").GetComponent<State>();

        near = 5;
        stop = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (State.isPossessed == true && State.isDead == false)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            player = GameObject.FindGameObjectWithTag("Soul").GetComponent<Transform>();
        }
        else if (State.isPossessed == false && State.isDead == false)
        {
            
            player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
            print("----"+player);
        }

        if (State.isDetected == true && State.isPossessed == false && this.gameObject.layer == 10)
        {
            if (Vector2.Distance(player.position, this.transform.position) < hazmatRange)
            {
                suckSource.Stop();
                if (player.position.x < this.transform.position.x)
                {
                    this.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0 * Time.deltaTime);
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
                    suckSource.Play();
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
        if (player.position.x < transform.position.x && this.transform.localScale.x > 0 && State.isDead == false)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        }
        else if (player.position.x >= transform.position.x && this.transform.localScale.x < 0 && State.isDead == false)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

        }

        if (State.isPossessed == true && target.position.x < transform.position.x && this.transform.localScale.x > 0)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            isleftnaja = true;
        }
        else if (State.isPossessed == true && target.position.x >= transform.position.x && this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            isleftnaja = false;
        }







        if (State.isPossessed == true && Vector2.Distance(transform.position, target.position) < near)
        {
            State.isNear = true;
            Vector3 newPos = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            newPos.y = transform.position.y;
            transform.position = newPos;
            
        }
        else if (State.isPossessed == true && Vector2.Distance(transform.position, target.position) > stop)
        {
            State.isNear = false;
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, -2.1f), target.position, speed * Time.deltaTime);

        }
        else if (State.isPossessed == true && Vector2.Distance(transform.position, target.position) < stop && Vector2.Distance(transform.position, target.position) > near)
        {
            transform.position = this.transform.position;
        }
        if (State.isPossessed == true && Vector2.Distance(transform.position, target.position) < shootingRange)
        {
            if (this.gameObject.layer == 9 && !delay)
            {
                Rigidbody2D instantiatedProjectile = Instantiate(projectile, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as
                Rigidbody2D;
                if (target.transform.position.x < this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(-20, 0);
                }
                else if (target.transform.position.x > this.transform.position.x)
                {
                    instantiatedProjectile.velocity = new Vector2(20, 0);
                }

                delaytime = 1;
                delay = true;
            }
        }

        if (delay)
        {
            delaytime -= Time.deltaTime;
            if (delaytime <= 0)
            {
                delay = false;
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Soul" && State.isDetected == true && this.gameObject.layer == 10)
        {
            collision.gameObject.SetActive(false);
            Time.timeScale = 0;
            Debug.Log("HZHit!!");
            StartCoroutine(waitOneFrame());
            state.GameOver();
        }

    }

    IEnumerator waitOneFrame()
    {
        yield return null;

    }
}