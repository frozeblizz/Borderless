using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBulletBehaviour : MonoBehaviour
{
    public GameObject[] blood;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 1.5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("AI_Hit!!");
                Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);

                collision.GetComponentInParent<DeadCon>().decreaseHP();
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            //Destroy(gameObject);
        }
    }




}