using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

	public Rigidbody2D projectile;
    public float speed = 20;
    public float fireRate;
    private float nextFire;
    public GameObject Controller;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Rigidbody2D instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as
            Rigidbody2D;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        }
    }
}
