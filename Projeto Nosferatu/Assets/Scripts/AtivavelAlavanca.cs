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

    float timer = 2f;

    public override void Ativar()
    {
        testeLiga = true;
        GetComponent<Animator>().SetBool("ativouAlavanca", true);
        GetComponent<AudioSource>().PlayOneShot(audioAlavanca);

        
    }

    private void Update()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].ligado = testeLiga;
        }

        luzBranca.SetActive(testeLiga);

        if (testeLiga)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                gameObject.GetComponent<Selecionavel>().enabled = false;
                gameObject.GetComponent<mouseCursor>().enabled = false;
                gameObject.GetComponent<AtivavelAlavanca>().enabled = false;
            }
        }
    }
}
