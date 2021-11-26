using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelTampaCaixao : Ativavel
{
    [SerializeField]
    GameObject receptorDeLuz;

    public override void Ativar()
    {
        FindObjectOfType<Animator>().SetBool("openCaixao", true);
        receptorDeLuz.SetActive(false);
    }
}
