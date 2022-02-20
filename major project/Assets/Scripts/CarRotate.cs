using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotate : MonoBehaviour
{
    public bool grounded;
    
    public float rotationSpeed=10f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.rotation.z >= 0.1 || gameObject.transform.rotation.z <= -0.1)
        {
            grounded = false;
        }
        else { grounded = true; }


        Debug.Log(gameObject.transform.rotation);

        
        if (!grounded)
        {
          transform.Rotate(0, 0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
