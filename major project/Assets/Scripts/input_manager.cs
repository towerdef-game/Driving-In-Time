using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_manager : MonoBehaviour
{
    public float vertical;
    public float horizontonal;
    public bool handbrake;
    public bool ebreak;

    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontonal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") !=0)? true : false;
        ebreak = (Input.GetAxis("Fire1") != 0) ? true : false;
    }
}
