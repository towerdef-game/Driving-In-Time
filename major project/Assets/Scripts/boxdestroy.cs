using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxdestroy : MonoBehaviour
{
    public GameObject boxpieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.tag == "Player")
        {
            Instantiate(boxpieces, transform.position, Quaternion.identity);
            Destroy(gameObject);



        }
    }
   
}
