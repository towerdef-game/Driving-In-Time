using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpinning : MonoBehaviour
{
    //FinbarRespawn spawned;
    //GameObject parent;

   
    public float spinSpeed = 1f;
    
    void Start()
    {
      //  parent.GetComponentInParent<FinbarRespawn>();
        //spawned.GetComponentInParent<FinbarRespawn>();
       
        //spawned.isSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 1f * spinSpeed, 0f, Space.Self);
    }
}
