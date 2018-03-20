using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
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
                TimeBehaviour.time += 3;
                ScoreBehaviour.scorepoint += 150;
            }
            else
            if (collision.gameObject.tag == "Body")
            {
                Debug.Log("Body shot!!");
                ScoreBehaviour.scorepoint += 100;
            }
        }
    }




}