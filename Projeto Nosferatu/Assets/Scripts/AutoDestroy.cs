using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public AudioClip[] pedras;
    public AudioSource audioS;
    public float tempo;
    void Start()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(pedras[Random.Range(0,pedras.Length)]);
    }

    void Update()
    {
        tempo -= Time.deltaTime;

        if(tempo <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
