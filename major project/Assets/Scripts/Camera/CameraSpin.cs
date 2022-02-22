using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    public GameObject center; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(center.transform.position);
        transform.RotateAround(center.transform.position, Vector3.up,15 * Time.deltaTime);
    }
}
