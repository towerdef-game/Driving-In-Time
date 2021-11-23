using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public GameManager manager;
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            manager.Endgame();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
