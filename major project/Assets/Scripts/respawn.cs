using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public float waittime;
    private float tmt;
    public GameObject power;
 //   public BoxCollider box;
    //   public GameObject body;
    // Start is called before the first frame update
    public void Start()
    {
        Instantiate(power, transform.position, transform.rotation);
   //     power.transform.parent = gameObject.transform;
    }
    public void timer()
    {
        tmt = waittime;
        StartCoroutine(bl());

    }
    public IEnumerator bl()
    {

        yield return new WaitForSeconds(tmt);
        Instantiate(power, transform.position, transform.rotation);
        

    }
}
