using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightening : MonoBehaviour
{
    Vector3 spawn;
    float timer;
    public GameObject thunderStrike;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            spawn = new Vector3(Random.Range(-100, 100), 50, Random.Range(-100, 100));

            GameObject clone= Instantiate(thunderStrike, spawn,Quaternion.identity);
           
                
            clone.SetActive(false);
            clone.SetActive(true);
            Destroy(clone, 1f);
            timer = Random.Range(1, 5);
        }
    }
}
