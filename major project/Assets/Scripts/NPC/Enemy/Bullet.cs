using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Bullet : MonoBehaviour
{


    Health hp;
    public float speed = 20f;
  
    private Vector3 carPastPos;

    //AudioSource explode;
    //public AudioClip boom;
    public StudioEventEmitter explosion;

    void Start()
    {
        //explode = GetComponent<AudioSource>();
        //explode.clip = boom;
      
        carPastPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dist = target.position - transform.position;


       Debug.Log(carPastPos);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, carPastPos, step);
        //  transform.rotation.SetLookRotation(carPastPos);
        transform.LookAt(carPastPos); 
        Destroy(this.gameObject, 10f);
        //destroys after ten seconds
    }


    void OnCollisionEnter(Collision other)
    {
      //  Destroy(this.gameObject);
        Debug.Log("hit" + other.gameObject.name);
              if (other.gameObject.tag == "Player")
        {
            //health loss code here ? 
               other.rigidbody.AddExplosionForce( 100000, transform.position, 10, 10, ForceMode.Force);
        }
        else if (other.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("bullet hit ground");
        }

       

 
 

      
        
    }
}
