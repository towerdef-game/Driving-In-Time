using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
   // public Transform player;
   // public Transform spawnPoint;


    public float remainingTime = 10;
    public bool timerIsOn = false;
    public float remainingTimeTillSpawn = 3;
    public bool timerIsOnToSpawn = false;
    public Transform playerPosition;
    public Vector3 respawnPosition;
    public bool grounded = false;
    private void Start()
    {
       
        timerIsOn = true;
        timerIsOnToSpawn = false;
    }
    void Update()
    {
        if (timerIsOn)// timer is on and grounded
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
               
            }
            else
            {
                remainingTime = 10;
                // take the players vector 3 position
               
               respawnPosition = playerPosition.transform.position;

            }
        }

        if (timerIsOnToSpawn)
        {
            
          

            if (remainingTimeTillSpawn > 0)
            {
                remainingTimeTillSpawn -= Time.deltaTime;

            }
            else
            {
                remainingTime = 10;
                remainingTimeTillSpawn = 1;
                playerPosition.position = respawnPosition;
                timerIsOn = true;
                timerIsOnToSpawn = false;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit trigger");

        if (other.gameObject.tag == "DeathField")
        {
           // Debug.Log("hit trigger");

            timerIsOnToSpawn = true;
            timerIsOn = false;

        }
    }
}
