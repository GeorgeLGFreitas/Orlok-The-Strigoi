using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float tempo;
    void Start()
    {
        
    }

    void Update()
    {
        tempo -= Time.deltaTime;

        if(tempo <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
