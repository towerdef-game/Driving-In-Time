using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager manager;
    public Material mat;
    public float pointvalue;
    private bool disolve = false; 
    public float currentdisolve = 0f;
    private CapsuleCollider cap;
  
    // Start is called before the first frame update
    void Start()
    {
        manager.targetsalive++;
        mat.SetFloat("_dispell", 0f);
        cap = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // currently disolves all when activated
    //if (disolve == true)
    //    {
    //        currentdisolve = Mathf.Lerp(currentdisolve, 1, 0.5f * Time.deltaTime);
    //        mat.SetFloat("_dispell", currentdisolve);
    //    }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
             Debug.Log("Collided");
            Destroy(cap);
            manager.score += pointvalue;
            manager.targetsalive--;
            disolve = true;

            // temporary change to instant while disolve isnt working
            //   Destroy(gameObject,3.5f);
            Destroy(gameObject);
       

        }
    }
   
   
}
