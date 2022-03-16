using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel_spin : MonoBehaviour
{
    public GameObject[] wheeltorotate;
    public float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxisRaw("Vertical");

        foreach(var wheel in wheeltorotate)
        {
            wheel.transform.Rotate(0, 0, Time.deltaTime * forward * rotationspeed, Space.Self);
        }
    }
}
