using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariacaoFogo : MonoBehaviour
{
    public Light luz; //10.4 - 4.0
    float timer;
    public float Timer;

    float minLuz1, maxLuz1, minLuz2, maxLuz2, alvo;
    public bool luz1, luz2;
    

    private void Start() 
    {
        minLuz1 = 8;
        maxLuz1 = 11;
        minLuz2 = 25;
        minLuz2 = 30;


        
        if(luz1)
        {            
            alvo = 0;
        }
        if(luz2)
        {            
            alvo = 0;
        }
    }

    void FixedUpdate()
    {      
        
        if(luz1)
        {
            do
            {
                if(alvo > luz.intensity)
                luz.intensity += 0.1f; 
                else
                luz.intensity -= 0.1f;           

            }
            while(luz.intensity != alvo); 

            if(luz.intensity == alvo)
            {
                alvo = Random.Range(minLuz1, maxLuz1);
            }   
        }

        if(luz2)
        {
            do
            {
                if(alvo > luz.intensity)
                luz.intensity += 0.1f; 
                else
                luz.intensity -= 0.1f;           

            }
            while(luz.intensity != alvo); 

            if(luz.intensity == alvo)
            {
                alvo = Random.Range(minLuz2, maxLuz2);
            }   
        }        
    }  
}
