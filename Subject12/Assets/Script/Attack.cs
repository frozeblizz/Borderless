using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject[] blood;
	public Rigidbody2D projectile;
    public float speed = 20;
    public float fireRate;
    private float nextFire;
    public AudioClip gunSound;
    public AudioSource gunSource;
    public AudioClip knifeSound;
    public AudioSource knifeSource;


    Rigidbody2D instantiatedProjectile;

    void Start()
    {
        gunSource.clip = gunSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Attacking();
        }
    }

    public void Attacking()
    {
            if (this.gameObject.layer == 9)
            {
                instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as
                Rigidbody2D;
                gunSource.Play();

                if (Controller.right == true)
                {
                    instantiatedProjectile.velocity = new Vector3(20, 0, 0);
                }
                else if (Controller.left == true)
                {
                    instantiatedProjectile.velocity = new Vector3(-20, 0, 0);
                }

            }
            if (this.gameObject.layer == 8)
            {
                this.GetComponentInParent<Animator>().SetBool("attack", true);
                knifeSource.Play();
                
                StartCoroutine(delay());
                Debug.Log("atk");
            }
            if (this.gameObject.layer == 10)
            {
                this.GetComponentInParent<Animator>().SetBool("attack", true);
                StartCoroutine(delay());
                Debug.Log("atk");
            }

        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(this.gameObject.layer == 8)
        {
            if (collider.gameObject.tag == "AI")
            {
                Debug.Log("DRHIT");
                collider.GetComponentInParent<DeadCon>().decreaseHP();
            }
        }
        
        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1 * Time.deltaTime);
        this.GetComponentInParent<Animator>().SetBool("attack", false);
    }

}
