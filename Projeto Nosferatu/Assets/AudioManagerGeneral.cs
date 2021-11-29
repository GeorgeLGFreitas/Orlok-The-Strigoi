using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGeneral : MonoBehaviour
{

    public AudioSource pilarS;
    public AudioSource pilarS2;
    public AudioSource pilarS3;
    public AudioSource pilarS4;
    public AudioSource gaiolaS;
    public AudioSource sarcofagoS;
    public AudioClip[] pilares;
    public AudioClip gaiola;
    public AudioClip sarcofago;

    public void _pilarS()
    {
        pilarS.pitch = Random.Range(0.85f,1);
        pilarS.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS2()
    {
        pilarS2.pitch = Random.Range(0.85f,1);
        pilarS2.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS3()
    {
        pilarS3.pitch = Random.Range(0.85f,1);
        pilarS3.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS4()
    {
        pilarS4.pitch = Random.Range(0.85f,1);
        pilarS4.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _gaiola()
    {
        gaiolaS.PlayOneShot(gaiola);
    }
    public void _sarcofago()
    {
        sarcofagoS.PlayOneShot(sarcofago);
    }

}
