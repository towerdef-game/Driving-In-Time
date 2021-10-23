using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject car;
    public GameObject camer;
    public Transform[] camlocations;
    public float loactionindicator;



    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
        camer = car.transform.Find("camera").gameObject;

    }
}