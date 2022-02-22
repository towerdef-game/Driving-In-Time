using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public car_mk3 carcontroller;
    public GameObject needle;
    private float startposition = 236f, endposition = 2f;
    private float position;
    public float vehiclespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        vehiclespeed = carcontroller.KPH;
        updateneedle();
    }
    public void updateneedle()
    {
        position = startposition - endposition;
        float temp = vehiclespeed / 180;
        needle.transform.eulerAngles = new Vector3(0, 0, (startposition - temp * position));
    }
}
