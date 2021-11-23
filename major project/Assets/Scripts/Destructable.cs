using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("car"))
        {
            if (GaintMode.gaintMode == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
