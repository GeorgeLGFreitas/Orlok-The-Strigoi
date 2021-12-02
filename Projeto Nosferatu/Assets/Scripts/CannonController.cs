using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float BlastPower;
    float bPower;
    float bPowerT;
    float bPowerTC;
    public AnimationManager animator;
    public bool mirando;
    public GameObject Cannonball;
    public GameObject Cannongarrafa;
    public Transform ShotPoint;


    Stats stats;

    void Start()
    {
        bPower = BlastPower;

        stats = GetComponent<Stats>();

        animator = GetComponent<AnimationManager>();
    }
    private void LateUpdate()
    {
        if (stats.atualPedra != 0 & stats.itemsGroupBool[0] == true || stats.atualGarrafa != 0 & stats.itemsGroupBool[1] == true)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                stats.primeiroTiro = true;

                mirando = true;
                bPowerT += Input.mouseScrollDelta.y * 0.3f;
                bPowerTC = Mathf.Clamp(bPowerT, 5, 13);
                bPowerT = bPowerTC;
                BlastPower = bPowerT;

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    animator.arremesso();
                }
            }
            else
            {
                BlastPower = bPower;
                mirando = false;
            }
        }
        else
        {
            BlastPower = bPower;
            mirando = false;
        }
    }

    public void Throw()
    {
        if (stats.itemsGroupBool[0] == true)
        {
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

            stats.arremessouPrimeiraVez = true;
            stats.atualPedra--;
        }
        if (stats.itemsGroupBool[1] == true)
        {
            GameObject CreatedCannonGarrafa = Instantiate(Cannongarrafa, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonGarrafa.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

            stats.atualGarrafa--;
        }
    }
}