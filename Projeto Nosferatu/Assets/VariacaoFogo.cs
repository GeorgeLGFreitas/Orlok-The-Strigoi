using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariacaoFogo : MonoBehaviour
{
    public Light luz; //10.4 - 4.0
    float timer;
    public float Timer;

    int minLuz1, maxLuz1, minLuz2, maxLuz2, alvo;
    public bool luz1, luz2;

    float luzIntensidade;

    private void Start() 
    {
        minLuz1 = 5;
        maxLuz1 = 15;
        minLuz2 = 10;
        maxLuz2 = 30;

        luz.intensity = 0;
        
        if(luz1)
        {            
            alvo = (int)Random.Range(minLuz1, maxLuz1);
        }
        if(luz2)
        {            
            alvo = (int)Random.Range(minLuz2,maxLuz2);
        }
    }

    void Update()
    {

        if (luz1)
        {
            if (luz.intensity != alvo)
            {
                if (alvo > luzIntensidade)
                {
                    luzIntensidade += 20 * Time.deltaTime;
                    if (luzIntensidade > alvo)
                    {
                        alvo = (int)Random.Range(minLuz1, maxLuz1);
                    }
                }
                else
                {
                    luzIntensidade -= 20 * Time.deltaTime;
                    if (luzIntensidade < alvo)
                    {
                        alvo = (int)Random.Range(minLuz1, maxLuz1);
                    }
                }
            }
        }

        if(luz2)
        {
            if (luz.intensity != alvo)
            {
                if (alvo > luzIntensidade)
                {
                    luzIntensidade += 20 * Time.deltaTime;
                    if (luzIntensidade > alvo)
                    {
                        alvo = (int)Random.Range(minLuz2, maxLuz2);
                    }
                }
                else
                {
                    luzIntensidade -= 20 * Time.deltaTime;
                    if (luzIntensidade < alvo)
                    {
                        alvo = (int)Random.Range(minLuz2, maxLuz2);
                    }
                }
            }
        }

        luz.intensity = luzIntensidade;
    }  
}
