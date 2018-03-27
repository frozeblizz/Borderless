using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float left;
    public float right;
    public float up;
    public float down;

    public GameObject cam;
    public GameObject target;
    
	
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPosition = cam.transform.position;
        
        cam.transform.position = new Vector3(targetPosition.x, targetPosition.y,cameraPosition.z);

        if (cam.transform.position.x <= -5.64f)
        {
            cam.transform.position = new Vector3(-5.64f, cam.transform.position.y, cam.transform.position.z);
        }
        if (cam.transform.position.x >= 4.14f)
        {
            cam.transform.position = new Vector3(4.14f, cam.transform.position.y, cam.transform.position.z);
        }
        if (cam.transform.position.y <= 0.48f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 0.48f, cam.transform.position.z);
        }
        if (cam.transform.position.y >= 3.48f)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, 3.48f, cam.transform.position.z);
        }
    }
}
