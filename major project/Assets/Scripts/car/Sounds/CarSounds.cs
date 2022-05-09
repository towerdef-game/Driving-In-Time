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
    public StudioEventEmitter powerUps;
    public StudioEventEmitter hitSounds;
    public StudioEventEmitter CarHit;
    void Start()
    {

        //audioSource = GetComponent<AudioSource>();

        car = GetComponent<Rigidbody>();

    }

    void Update()
    {
        motor.SetParameter("velocity", car.velocity.magnitude / 5);
        carSounds.SetParameter("velocity", car.velocity.magnitude);
        CarHit.SetParameter("velocity", car.velocity.magnitude / 5);
        timer -= 1 * Time.deltaTime;
        // Debug.Log(car.velocity.magnitude);
        if (car.velocity.magnitude > previousSpeed)
        {
            previousSpeed = car.velocity.magnitude;
            if (timer <= 0)
            {
                //audioSource.clip = accel;
                // motor.Play();
                timer = 2;
            }

        }
        else if (car.velocity.magnitude < previousSpeed)
        {
            previousSpeed = car.velocity.magnitude;

            if (timer <= 0)
            {

                //audioSource.clip = slow;
                //audioSource.Play();
                //audioSource.PlayOneShot(slow,2f);
                timer = 2;
            }

        } else if (car.velocity.magnitude <= 0.3f)
        {
            if (timer <= 0)
            {

                //audioSource.clip = stanby;
                //audioSource.Play();
                //audioSource.PlayOneShot(stanby, 2F);
                timer = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("works");
            carSounds.SetParameter("honk", 1);
            carSounds.SetParameter("honk", 0);
            // RuntimeManager.PlayOneShot("event:/Car",transform.position);
            //audioSource.PlayOneShot(honk, 2F);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //  audioSource.PlayOneShot(ablity, 0.7F);


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NonEnemy"))
        {
            // Debug.Log("im real please save me");
            //int voice = Random.Range(1, 8);
            // hitSounds.SetParameter("Random", voice);
            // hitSounds.SetParameter("objectType", 1);
            hitSounds.Play();
            // RuntimeManager.PlayOneShot("Hitcharacter", transform.position);

        }

        if (collision.gameObject.CompareTag("Solid"))
        {
            CarHit.Play();
        }

    }
    }
