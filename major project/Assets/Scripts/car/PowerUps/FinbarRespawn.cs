using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinbarRespawn : MonoBehaviour
{
    public GameObject[] powerups;
    public GameObject self;
   public bool isSpawned=false;
    public float time=10f ; 
    void Start()
    {
       // self = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            isSpawned = true;
        }
        else isSpawned = false;

       
        if (!isSpawned)
        {
            time -= 1 * Time.deltaTime;
            if (time <= 0)
            {
               
                Instantiate(powerups[Random.Range(0, powerups.Length)], transform.position, Quaternion.identity, self.transform);
             


            }
        }
        else time = 10f;
    }
}
