using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager manager;
    public float pointvalue;
    // Start is called before the first frame update
    void Start()
    {
        manager.targetsalive++; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
             Debug.Log("Collided");
            manager.score += 10;
            manager.targetsalive--;
            Destroy(this);

        }
    }
}
