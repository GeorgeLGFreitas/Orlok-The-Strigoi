using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertaBT : MonoBehaviour
{
    public bool _destrutivel;


    public Transform prefab;
   
    void OnCollisionEnter(Collision other)
    {

        Instantiate(prefab, transform.position, Quaternion.identity);
       

        if (_destrutivel && !other.collider.CompareTag("Pedra"))
        {
            Debug.Log(other.collider.gameObject);
            Destroy(gameObject);
        }
    }


}
