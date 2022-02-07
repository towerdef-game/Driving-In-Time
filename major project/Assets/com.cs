using System.Collections;

using UnityEngine;

public class com : MonoBehaviour
{
    public Vector3 cenofmas;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = cenofmas;
    }

    // Update is called once per frame
   
}
