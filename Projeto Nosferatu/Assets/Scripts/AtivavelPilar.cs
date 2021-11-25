using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPilar : Ativavel
{
    [SerializeField]
    GameObject Pilar;

    bool giraPilar = false;

    float timer = 2f;

    private void Update()
    {
        if (giraPilar)
        {
            timer -= Time.deltaTime;

            Pilar.transform.Rotate(Vector3.up, Time.deltaTime * -45);
            if (timer <= 0)
            {
                timer = 2f;
                giraPilar = false;
            }
        }
    }

    public override void Ativar()
    {
        giraPilar = true;
    }
}
