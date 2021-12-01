using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancaRodar : MonoBehaviour
{

    float timer;

    public float quantidade;
    public bool rodaBalanca;

    public GameObject lado1, lado2;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        rodaBalanca = false;
        //RodaBalanca1();
    }

    // Update is called once per frame
    void Update()
    {
        if(rodaBalanca)
        {
            timer -= Time.deltaTime;
            gameObject.transform.Rotate(Vector3.forward, Time.deltaTime * quantidade / 9);
            lado1.transform.Rotate(Vector3.forward, Time.deltaTime * -quantidade / 9 );
            lado2.transform.Rotate(Vector3.forward, Time.deltaTime * -quantidade / 9);
            if(timer <= 0)
            {
                //gameObject.transform.Rotate(Vector3.forward, Time.deltaTime * 7.5f);
                rodaBalanca = false;
            }
        }
        
    }


    public void RodaBalanca1()
    {
        rodaBalanca = true;
        timer = 1;
    } 

    public void RodaBalanca2()
    {

    }
}
