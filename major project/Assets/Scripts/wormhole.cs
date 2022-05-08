using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormhole : MonoBehaviour
{
    public Rigidbody car;
    public CarRotate ro;
    public GameObject buildup;
    public switchcamera cam;

    // Start is called before the first frame update
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            car.isKinematic = false;
            ro.enabled = true;
            buildup.SetActive(false);
            cam.enabled = true;
        }
  
    }
}
