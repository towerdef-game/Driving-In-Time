using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    Rigidbody car;
    AudioSource hitPerson;
    void Start()
    {
        car = GetComponent<Rigidbody>();
        hitPerson = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        

         Debug.Log("hit?");
        other.attachedRigidbody.isKinematic = false;
        if (other.gameObject.CompareTag("Collidable"))
        {
            //Rigidbody one;
            //  one = GetComponent<Rigidbody>;
            Debug.Log("hit?");
            other.attachedRigidbody.isKinematic = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // other.col
        Debug.Log(collision.gameObject.name);
        
        
        if (collision.gameObject.CompareTag("Collidable"))
        {

            collision.rigidbody.AddForce(car.velocity);
         hitPerson.Play();
           
        }
       // Debug.Log("hit?");
       
    }
}
