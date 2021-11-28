using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerOrlok : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip[] passos;
    public AudioClip gole;
    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Passinho()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(passos[Random.Range(0,passos.Length)], 0.65f);
    }

    public void Passao()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(passos[Random.Range(0,passos.Length)], 0.75f);
    }

    public void Golinho()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(gole);
    }
}
