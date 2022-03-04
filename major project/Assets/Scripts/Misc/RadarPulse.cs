using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadarPulse : MonoBehaviour
{
    public Transform sweepTransfrom;
    public float rotateSpeed = 180f;


    public void Start()
    {
        
    }

    public void Update()
    {
        sweepTransfrom.eulerAngles -= new Vector3(0, 0, rotateSpeed * Time.deltaTime);
    }
}
