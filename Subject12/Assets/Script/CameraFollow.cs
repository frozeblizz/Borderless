using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    public GameObject cam;
    public GameObject target;


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            target = GameObject.Find("Player");
        }
        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPosition = cam.transform.position;

        cam.transform.position = new Vector3(targetPosition.x, targetPosition.y+2.32f, cameraPosition.z);

        if (cam.transform.position.x <= -1.82f)
        {
            cam.transform.position = new Vector3(-1.82f, cam.transform.position.y, cam.transform.position.z);
        }
        if (cam.transform.position.x >= 22.1f)
        {
            cam.transform.position = new Vector3(22.1f, cam.transform.position.y, cam.transform.position.z);
        }
        if (cam.transform.position.y <= -7.11f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, -7.11f, cam.transform.position.z);
        }
        if (cam.transform.position.y >= 11f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 11f, cam.transform.position.z);
        }
    }
}
