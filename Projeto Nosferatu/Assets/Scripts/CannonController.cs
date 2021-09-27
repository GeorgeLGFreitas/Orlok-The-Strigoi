using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float BlastPower;

    float bPower;
    float bPowerT;
    float bPowerTC;

    public bool mirando;
    public GameObject Cannonball;
    public Transform ShotPoint;

    void Start()
    {
        bPower = BlastPower;
    }
    private void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {   
            mirando = true;
            bPowerT += Input.mouseScrollDelta.y * 0.3f;
            bPowerTC = Mathf.Clamp(bPowerT,5,10);
            bPowerT = bPowerTC;
            BlastPower = bPowerT;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
                CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            }
        }
        else
        {
            BlastPower = bPower;
            mirando = false;
        }
      
    }


}