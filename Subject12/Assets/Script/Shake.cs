using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shake : MonoBehaviour
{
    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay = 0.002f;
    public float shake_intensity = .3f;
    private Animator anim;

    private float temp_shake_intensity = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        if (this.gameObject.tag == "Start")
        {
            anim.SetTrigger("IsClick");
            ShakeObject();
            StartCoroutine(Wait(300.0f));
            
        }
    }

    void Update()
    {
        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }
    }

    void ShakeObject()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;

    }

    IEnumerator Wait(float seconds)
    {

        yield return new WaitForSeconds(seconds * Time.deltaTime);
        SceneManager.LoadScene("Prototype");
    }


}
