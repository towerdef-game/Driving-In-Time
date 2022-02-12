using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roataewheel : MonoBehaviour
{
    // public GameObject steeringwheel;
    public float wheelrotation;
    public float speed;
    public Quaternion TO;
    
    //  public float wheel;


    private void Start()
    {
        // TO = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    public void FixedUpdate()
    {


        wheelrotation += Input.GetAxis("Horizontal")*speed;
        wheelrotation = Mathf.Clamp(wheelrotation, -120, 120);
        transform.Rotate(0, 0, -wheelrotation, Space.Self);
          transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -wheelrotation);
       // transform.rotation = new Vector3(-wheelrotation);
      
    }
    public void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
         //roatates the wheel back to orignal place
            wheelrotation = Mathf.Lerp(wheelrotation, 0f, 1f*Time.deltaTime);
        }
    }
}
