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
    AudioSource audioSource;

   // AudioSource soundsource;
   // for some reason didnt work even though itwas the exact same as The other one?
    public AudioClip accel;
    public AudioClip slow;
    public AudioClip stanby;
    public AudioClip honk;
    public AudioClip ablity;

    public StudioEventEmitter motor;

    FMOD.Studio.EventInstance instance;
    power_Up_State powerState; 

    void Start()
    {
        motor = GetComponent<StudioEventEmitter>();
        audioSource = GetComponent<AudioSource>();
        powerState = GetComponent<power_Up_State>();
        car = GetComponent<Rigidbody>();
       
    }
    
    void Update()
    {


        //motor.Params.SetValue(car.velocity.magnitude);
        motor.SetParameter("velocity", car.velocity.magnitude/100);
        if (car.velocity.magnitude >= 1)
        {
            motor.SetParameter("isAccel", 1f);
        }
        else motor.SetParameter("isAccel", 0);


        timer -= 1 * Time.deltaTime;
       Debug.Log(car.velocity.magnitude/100);
        //if (car.velocity.magnitude >previousSpeed)
        //{
        //    previousSpeed = car.velocity.magnitude;
        //    if (timer <= 0)
        //    {
        //        audioSource.clip = accel;
        //        audioSource.Play();
        //        timer = 2;
        //    }

        //}
        //else   if (car.velocity.magnitude< previousSpeed)
        //{
        //    previousSpeed = car.velocity.magnitude;

        //    if (timer <= 0)
        //    {

        //        audioSource.clip = slow;
        //        audioSource.Play();
        //        //audioSource.PlayOneShot(slow,2f);
        //        timer = 2;
        //    }

        //} else
        //
        if(car.velocity.magnitude<=0.1f)
        {
            if (timer <= 0)
            {

                audioSource.clip = stanby;
                audioSource.Play();
                //audioSource.PlayOneShot(stanby, 2F);
                timer = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
          // Debug.Log("works");
            audioSource.PlayOneShot(honk, 2F);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {



            if (powerState._state != power_Up_State.powers_manage.nopower)
            {
             //   Debug.Log("works? audio");
                audioSource.PlayOneShot(ablity);
            }


        }
    }


  
}
