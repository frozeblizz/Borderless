using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject[] blood;
	public Rigidbody2D projectile;
    public float speed = 20;
    public float fireRate;
    private float nextFire;
    

   
    Rigidbody2D instantiatedProjectile;

    void Start()
    {
        
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

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1 * Time.deltaTime);
        this.GetComponentInParent<Animator>().SetBool("attack", false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Body" && this.GetComponentInParent<Animator>().GetBool("attack"))
        {
            Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);
            ScoreBehaviour.scorepoint += 100;
            collision.GetComponentInParent<DeadCon>().decreaseHP();
        }
        if (collision.tag == "Head" && this.GetComponentInParent<Animator>().GetBool("attack"))
        {
            Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);
            ScoreBehaviour.scorepoint += 150;
            collision.GetComponentInParent<DeadCon>().Dead();
        }
    }

}
