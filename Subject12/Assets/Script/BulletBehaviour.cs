using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject[] blood;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1.5f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Head")
            {
                Debug.Log("HeadShot!!");
                Instantiate(blood[Random.Range(0, 10)], this.transform.position, this.transform.rotation);
                TimeBehaviour.time += 3; 
                ScoreBehaviour.scorepoint += (int)(150 * ScoreBehaviour.multiplier);
                collision.GetComponentInParent<DeadCon>().Dead();
                Destroy(gameObject);
                
            }
            else
            if (collision.gameObject.tag == "Body")
            {
                Debug.Log("Body shot!!");
                Instantiate(blood[Random.Range(0, blood.Length)], this.transform.position, this.transform.rotation);
                ScoreBehaviour.scorepoint += (int)(100 * ScoreBehaviour.multiplier);
                collision.GetComponentInParent<DeadCon>().HP();
                Destroy(gameObject);
            }     
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }




}