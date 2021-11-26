using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPortaSemChave : Ativavel
{

    float timer = 4.5f;

    bool abrePorta = false;

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
            }
        }
    }

    public override void Ativar()
    {
        abrePorta = true;
        FindObjectOfType<QuestManager>().naArea3 = true;
    }
}