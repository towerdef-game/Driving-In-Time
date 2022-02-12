using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObj : MonoBehaviour
{
    Rigidbody car;
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // other.col
        Debug.Log(collision.gameObject.name);


       // if (collision.gameObject.CompareTag("Collidable"))
       // {
            collision.rigidbody.isKinematic = false;
            collision.rigidbody.AddForce(car.velocity);
            //hitPerson.Play();

       // }
        // Debug.Log("hit?");

    }
}
