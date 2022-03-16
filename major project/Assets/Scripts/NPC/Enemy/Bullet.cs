using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Bullet : MonoBehaviour
{


    Health hp;
    public float speed = 20f;
  
    private Vector3 carPastPos;

    AudioSource explode;
    public AudioClip boom;
    public StudioEventEmitter explosion;

    void Start()
    {
        explode = GetComponent<AudioSource>();
        explode.clip = boom;
      
        carPastPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dist = target.position - transform.position;


       Debug.Log(carPastPos);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, carPastPos, step);


        Destroy(this.gameObject, 10f);
        //destroys after ten seconds
    }


    void OnCollisionEnter(Collision other)
    {

        Debug.Log("hit" + other.gameObject.name);
              if (other.gameObject.CompareTag("Player"))
        {
            //health loss code here ? 
               other.rigidbody.AddExplosionForce( 100000, transform.position, 10, 10, ForceMode.Force);
        }

        //other.rigidbody.AddForce(enemy.velocity * 1000000);
        //for some reason wont collide with floor maybe because of its mesh collider?
        explode.Play();
            Destroy(this.gameObject);
        // one mil force? wot m8

      
        
    }
}
