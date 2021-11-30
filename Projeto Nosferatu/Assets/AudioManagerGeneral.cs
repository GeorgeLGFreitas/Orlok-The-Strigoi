using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        pilarS.Stop();
        pilarS.pitch = Random.Range(0.85f,1);
        pilarS.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS2()
    {
        pilarS2.Stop();
        pilarS2.pitch = Random.Range(0.85f,1);
        pilarS2.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS3()
    {
        pilarS3.Stop();
        pilarS3.pitch = Random.Range(0.85f,1);
        pilarS3.PlayOneShot(pilares[Random.Range(0,pilares.Length)], 0.65f);
    }

    public void _pilarS4()
    {
        pilarS4.Stop();
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

   
    public static IEnumerator StartFadeAS(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
 
    public static IEnumerator StartFadeAM(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(exposedParam, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(exposedParam, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

}
