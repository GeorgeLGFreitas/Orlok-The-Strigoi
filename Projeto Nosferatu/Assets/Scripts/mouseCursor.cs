using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public GameObject maoabt, maofecha, lupa, balao;
    /*public bool coletar, inspecionar, falar;

    void Start()
    {
        coletar = false;
        inspecionar = false;
        falar = false;
        

    }*/

    public void Mao() 
    {
        lupa.SetActive(false);
        balao.SetActive(false);
        maoabt.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            maofecha.SetActive(true);
            maoabt.SetActive(false);
        }
        
    }
    public void Lupa()
    {

        maoabt.SetActive(false);
        maofecha.SetActive(false);
        balao.SetActive(false);
        lupa.SetActive(true);
        
    }
    public void Balao()
    {

        maoabt.SetActive(false);
        maofecha.SetActive(false);
        balao.SetActive(true);
        lupa.SetActive(false);
        

    }

        






}
