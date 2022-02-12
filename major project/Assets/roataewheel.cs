using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roataewheel : MonoBehaviour
{
    // public GameObject steeringwheel;
    private float wheelrotation;
    public float speed;
    public float wheel;
    
  

    public void FixedUpdate()
    {
        wheelrotation += Input.GetAxis("Horizontal")*speed;
        wheelrotation = Mathf.Clamp(wheelrotation, -120, 120);
        transform.Rotate(0, 0, -wheelrotation, Space.Self);
        //  Vector3 current_rotation = transform.rotation.eulerAngles;
        //   current_rotation.z =  Mathf.Clamp(wheel, -120, 120);
        //   transform.rotation = Quaternion.Euler(-current_rotation);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -wheelrotation);

        if(Input.GetAxis("Horizontal") == 0)
        {
         //   Quaternion.Lerp();
        }
    }
}
