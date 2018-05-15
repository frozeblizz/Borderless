using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEffectVolume : MonoBehaviour
{

    void Start()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effect");

    }
}
