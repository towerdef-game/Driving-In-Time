using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nontarget : MonoBehaviour
{
    public GameManager manager;
    public GameObject body;
    private Rigidbody crash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            
            manager.NonEnemy++;
          //  Instantiate(body,transform.position,transform.rotation);
         //   GameObject clone = Instantiate(body, transform.position , Quaternion.identity);
          GameObject clone = Instantiate(body, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity);
            Rigidbody rag = clone.GetComponent<Rigidbody>();
            
            rag.AddForce(other.rigidbody.velocity*2);
            Destroy(gameObject);

            

        }
    }

}
