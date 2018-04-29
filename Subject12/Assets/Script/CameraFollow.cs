using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    public GameObject cam;
    public GameObject target;



    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPosition = cam.transform.position;

        cam.transform.position = new Vector3(targetPosition.x, targetPosition.y+2.32f, cameraPosition.z);

        if (cam.transform.position.x <= -15.25f)
        {
            cam.transform.position = new Vector3(-15.25f, cam.transform.position.y, cam.transform.position.z);
        }
        if (cam.transform.position.x >= 14.95f)
        {
            cam.transform.position = new Vector3(14.95f, cam.transform.position.y, cam.transform.position.z);
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
