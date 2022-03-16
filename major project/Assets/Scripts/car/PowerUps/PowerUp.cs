using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject[] spawnPowerUps;
    public Transform[] spawnPowerUpsLocations;
    // Start is called before the first frame update
    void Start()
    {
      for(int i = 0; i < spawnPowerUpsLocations.Length; i++)
        {
            //for (int i = 0; i < spawnPowerUpsLocations.Length; i++)
            //{
            //  Instantiate(spawnPowerUps[Random.Range(0, spawnPowerUps.Length)], spawnPowerUpsLocations[i]);
            //}
            Instantiate(spawnPowerUps[Random.Range(0, spawnPowerUps.Length)], spawnPowerUpsLocations[i].position,transform.rotation);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
