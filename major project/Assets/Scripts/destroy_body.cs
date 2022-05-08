using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //  StartCoroutine(acid);
        Destroy(gameObject, 8f);
    }

 
}
