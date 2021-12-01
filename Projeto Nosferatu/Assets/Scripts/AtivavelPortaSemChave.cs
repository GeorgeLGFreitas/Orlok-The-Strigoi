using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPortaSemChave : Ativavel
{

    float timer = 4.5f;

    bool abrePorta = false;

    public AudioClip abre;
    public AudioSource audioS;

    private void Update()
    {
        if (abrePorta)
        {
            timer -= Time.deltaTime;

            gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);
            if (timer <= 0)
            {
                timer = 4.5f;
                abrePorta = false;

                gameObject.GetComponent<Selecionavel>().enabled = false;
                gameObject.GetComponent<mouseCursor>().enabled = false;
                gameObject.GetComponent<AtivavelPortaSemChave>().enabled = false;
            }
        }
    }

    public override void Ativar()
    {
        abrePorta = true;
        audioS.PlayOneShot(abre);
    }
}
