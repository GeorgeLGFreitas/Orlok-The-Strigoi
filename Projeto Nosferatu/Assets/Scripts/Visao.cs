using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    
  public float sensibility = 0f;
  Transform braco;
  Vector3 bracoRotation = Vector3.zero;
  Vector3 point;
  
    void Start()
    {
    
        braco = transform.Find("Braco");
        Cursor.lockState = CursorLockMode.Locked;   
          
    }
    void Update()
    {   
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += Input.GetAxis("Mouse X") * sensibility;
        transform.localEulerAngles = rotation;
    
        bracoRotation.x -= Input.GetAxis("Mouse Y") * sensibility;
        bracoRotation.x = Mathf.Clamp(bracoRotation.x, -50, 50);
        braco.localEulerAngles = bracoRotation;     
    }
}
