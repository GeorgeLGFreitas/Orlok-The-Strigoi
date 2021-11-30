using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerNos: MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip[] passos;
    public AudioClip[] gritos;
    void Awake()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PassinhoNos()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(passos[Random.Range(0,passos.Length)], 0.65f);
    }

    public void PassaoNos()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(passos[Random.Range(0,passos.Length)], 0.75f);
    }

    public void Grito()
    {
        audioS.pitch = Random.Range(0.85f,1);
        audioS.PlayOneShot(gritos[Random.Range(0,gritos.Length)], 0.75f);
    }
}
