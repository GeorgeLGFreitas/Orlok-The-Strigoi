using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public GameObject maoabt, maofecha, lupa, balao;
    public bool coletar, inspecionar, falar;

    void Start()
    {
        coletar = false;
        inspecionar = false;
        falar = false;
        

    }

    private void OnMouseEnter() 
    {
        if(coletar)
        {
            maoabt.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                maofecha.SetActive(true);
                maoabt.SetActive(false);
            }
        } 
        if(inspecionar)
        {
            maoabt.SetActive(false);
            maofecha.SetActive(false);
            balao.SetActive(false);
            lupa.SetActive(true);

        }
        if(falar)
        {
            maoabt.SetActive(false);
            maofecha.SetActive(false);
            balao.SetActive(true);
            lupa.SetActive(false);
        }
    }

    





}
