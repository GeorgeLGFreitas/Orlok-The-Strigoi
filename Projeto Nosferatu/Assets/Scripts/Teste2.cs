using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste2 : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;




    void Start()

    {

        Vector2 pos1 = new Vector2(1, 7);

        Vector2 pos2 = new Vector2(1, 7);

        item3.transform.position = pos2 - pos1;

        item2.transform.position = pos1 + pos2;

        item1.transform.position = pos1;

        float valor = item3.transform.position.x + item3.transform.position.y;

        print(valor);

    }

}