using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    CharacterController ctrl;
    
    public float gravity, velocity, jump  = 0f;
    Vector3 movi = Vector3.zero;

    void Start()
    {
        ctrl = GetComponent<CharacterController>();

    }
    void Update() 
   {

       if(ctrl.isGrounded)
       {
           movi.y = 0;
           if(Input.GetButtonDown("Jump"))
           {
               movi.y = jump;
           }
       }

       movi.x = 0;
       movi.z = 0;

       movi += Input.GetAxis("Horizontal") * transform.right * velocity;
       movi += Input.GetAxis("Vertical") * transform.forward * velocity; 
       movi.y -= gravity * Time.deltaTime;

       ctrl.Move(movi * Time.deltaTime);
   }
}
