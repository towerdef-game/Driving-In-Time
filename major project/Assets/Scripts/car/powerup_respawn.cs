using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_respawn : MonoBehaviour
{
  //  public BoxCollider trigger;
    public float waittime;
    private float tmt;
    public GameObject power;
 //   public GameObject body;
    // Start is called before the first frame update
   public void timer()
    {
        tmt = waittime;
        StartCoroutine(bl());
     
    }
   public IEnumerator bl()
    {
       
            yield return new WaitForSeconds(tmt);
            Instantiate(power, transform.position, transform.rotation);
         //   StopCoroutine(bl());
            Destroy(gameObject);
        
    }
    
}
