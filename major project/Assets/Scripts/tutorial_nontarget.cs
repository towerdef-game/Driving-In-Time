using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_nontarget : MonoBehaviour
{
    public GameObject body;
    //private Rigidbody crash;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.tag == "Player")
        {
       

      ;
            GameObject clone = Instantiate(body, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Rigidbody rag = clone.GetComponent<Rigidbody>();

            rag.AddForce(other.rigidbody.velocity * 2);
            Destroy(gameObject);



        }
    }

}
