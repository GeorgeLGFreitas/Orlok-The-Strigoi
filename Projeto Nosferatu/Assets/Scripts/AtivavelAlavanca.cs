using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelAlavanca : Ativavel
{
    [SerializeField]
    Laser[] lasers;
    [SerializeField]
    GameObject luzBranca;

    public bool testeLiga;

    public override void Ativar()
    {
        testeLiga = true;
    }

    private void Start()
    {
        luzBranca.SetActive(false);
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
