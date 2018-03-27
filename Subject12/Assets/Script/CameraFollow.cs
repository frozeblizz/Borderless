using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    
    public GameObject cam;
    public GameObject target;
    
	
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = target.transform.position;
        Vector3 cameraPosition = cam.transform.position;
        
        cam.transform.position = new Vector3(targetPosition.x, cameraPosition.y,cameraPosition.z);
      
		if (cam.transform.position.x <= -2.52f)
        {
			cam.transform.position = new Vector3(-2.52f, cam.transform.position.y, cam.transform.position.z);
		}
        if (cam.transform.position.x >= 1.02f)
        {
			cam.transform.position = new Vector3(1.02f, cam.transform.position.y, cam.transform.position.z);
		}
	}
}
