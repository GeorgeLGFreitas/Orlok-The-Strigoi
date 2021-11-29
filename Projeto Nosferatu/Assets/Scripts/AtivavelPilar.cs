using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPilar : Ativavel
{
    [SerializeField]
    GameObject Pilar;

    bool giraPilar = false;

    public bool pilar1, pilar2, pilar3, pilar4;

    float timer = 2f;

    AudioManagerGeneral audioMG;

    void Start()
    {
        audioMG = FindObjectOfType<AudioManagerGeneral>();
    }

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

        if (pilar1 && timer == 2f)
        {
      
            audioMG._pilarS();
        }

        if (pilar2 && timer == 2f)
        {
            audioMG._pilarS2();
        }

        if (pilar3 && timer == 2f)
        {
            audioMG._pilarS3();
        }

        if (pilar4 && timer == 2f)
        {
            audioMG._pilarS4();
        }
    }
}
