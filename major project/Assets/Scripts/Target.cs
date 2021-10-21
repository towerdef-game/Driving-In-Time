using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager manager;
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
        if (other.gameObject.tag == "ObjectScore")
        {
            // Debug.Log("Collided");
            manager.score += 10;
            manager.targetsalive--;
            Destroy(this);

        }
    }
}
