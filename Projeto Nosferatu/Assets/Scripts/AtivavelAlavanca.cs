using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelAlavanca : Ativavel
{
    [SerializeField]
    Laser[] lasers;
    [SerializeField]
    GameObject luzBranca;
    [SerializeField]
    AudioClip audioAlavanca;

    public bool testeLiga;

    public override void Ativar()
    {
        testeLiga = true;
        GetComponent<Animator>().SetBool("ativouAlavanca", true);
        GetComponent<AudioSource>().PlayOneShot(audioAlavanca);

        gameObject.GetComponent<Selecionavel>().enabled = false;
        gameObject.GetComponent<mouseCursor>().enabled = false;
        gameObject.GetComponent<AtivavelAlavanca>().enabled = false;
    }

    private void Update()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].ligado = testeLiga;
        }

        luzBranca.SetActive(testeLiga);
    }
}
