using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class WormTravel : MonoBehaviour
{
    public StudioEventEmitter wormhole;
    public Collider car;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag== "Wormhole")
        {
            wormhole.SetParameter("switchSong", 1);
        }
    }
}
