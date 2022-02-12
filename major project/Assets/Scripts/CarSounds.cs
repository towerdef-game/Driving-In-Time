using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{
   
    
    
    
    
    
    private AudioSource soundsource;
    public AudioClip sound;
    void Start()
    {

       // soundsource.;


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("works");
            soundsource.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("works");
            //soundsource.Play();

        }
    }
}
