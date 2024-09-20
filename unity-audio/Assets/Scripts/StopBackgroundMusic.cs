using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBackgroundMusic : MonoBehaviour
{
    public AudioSource bgmAudioSource;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
            bgmAudioSource.Stop();  
        }
    }
}

