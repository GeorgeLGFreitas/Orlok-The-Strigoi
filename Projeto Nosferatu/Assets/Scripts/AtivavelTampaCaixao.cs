using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelTampaCaixao : Ativavel
{
    [SerializeField]
    GameObject receptorDeLuz;

    bool openCaixao = false;

    public override void Ativar()
    {
        openCaixao = true;
    }

    private void Update()
    {
        if (openCaixao)
        {
            GetComponent<Animator>().SetBool("openCaixao", true);
            receptorDeLuz.SetActive(false);
        }
    }
}
