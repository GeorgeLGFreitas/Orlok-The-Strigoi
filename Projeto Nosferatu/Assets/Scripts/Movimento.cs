using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    CharacterController ctrl;
    CannonController cannonC;

    
    public float gravity, velocity, jump  = 0f;

    float vel;
    float crouch;
    Vector3 movi = Vector3.zero;

    Stats stats;

    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        cannonC = GetComponent<CannonController>();
        stats = GetComponent<Stats>();
        vel = velocity;
        crouch = ctrl.height;

    }
    void Update() 
   {
       if(cannonC.mirando == true)
       {
           velocity = vel / 3;
       }
       else if (Input.GetKey(KeyCode.LeftShift) & cannonC.mirando == false & stats.atualStamina >= 0)
       {
            velocity = vel * 2;
       }
       else if(Input.GetKey(KeyCode.LeftControl))
       {
            ctrl.height = crouch/2;
            velocity = vel / 4;

            if(cannonC.mirando == true)
            {
                velocity = vel / 5;
            }
       }
       else 
       {
            ctrl.height = crouch;
            velocity= vel;
       }

    
       if(ctrl.isGrounded)
       {
           movi.y = 0;
           //if(Input.GetButtonDown("Jump"))
           //{
               //movi.y = jump;
           //}
       }

       
       
       
           
       


       movi.x = 0;
       movi.z = 0;
        
       movi += Input.GetAxis("Horizontal") * transform.right * velocity;
       movi += Input.GetAxis("Vertical") * transform.forward * velocity; 
       movi.y -= gravity * Time.deltaTime;

       ctrl.Move(movi * Time.deltaTime);
   }
}
