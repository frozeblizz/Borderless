using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemySpawn;
    public float speed = 5;
    public Rigidbody2D projectile;
    public float spawnRate;
    private float nextSpawn;

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as
            Rigidbody2D;
            yield return new WaitForSeconds(5);
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 0));
        }
        
    }


	// Update is called once per frame
	void Update () {


        

       
    }
}
