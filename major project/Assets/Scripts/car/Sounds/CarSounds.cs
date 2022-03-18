using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using FMODUnity;

public class CarSounds : MonoBehaviour
{



    Rigidbody car;
    Vector3 carmoving;
    float previousSpeed;
    float timer;
    //AudioSource audioSource;

   // AudioSource soundsource;
   // for some reason didnt work even though itwas the exact same as The other one?
    //public AudioClip accel;
    //public AudioClip slow;
    //public AudioClip stanby;
    //public AudioClip honk;
    //public AudioClip ablity;

    public StudioEventEmitter motor;
    public StudioEventEmitter carSounds;
    void Start()
    {
        
        //audioSource = GetComponent<AudioSource>();
  
        car = GetComponent<Rigidbody>();

    }
    
    void Update() 
    {
        motor.SetParameter("velocity", car.velocity.magnitude);
        timer -= 1 * Time.deltaTime;
       // Debug.Log(car.velocity.magnitude);
        if (car.velocity.magnitude >previousSpeed)
        {
            previousSpeed = car.velocity.magnitude;
            if (timer <= 0)
            {
                //audioSource.clip = accel;
               // motor.Play();
                timer = 2;
            }

        }
        else   if (car.velocity.magnitude< previousSpeed)
        {
            previousSpeed = car.velocity.magnitude;

            if (timer <= 0)
            {

                //audioSource.clip = slow;
                //audioSource.Play();
                //audioSource.PlayOneShot(slow,2f);
                timer = 2;
            }

        } else if(car.velocity.magnitude<=0.3f)
        {
            if (timer <= 0)
            {

                //audioSource.clip = stanby;
                //audioSource.Play();
                //audioSource.PlayOneShot(stanby, 2F);
                timer = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("works");

            //audioSource.PlayOneShot(honk, 2F);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //  audioSource.PlayOneShot(ablity, 0.7F);
            carSounds.SetParameter("honk", 1);


        }
    }


  
}
