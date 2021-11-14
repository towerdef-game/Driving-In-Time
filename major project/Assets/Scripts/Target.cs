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

  
    // Start is called before the first frame update
    void Start()
    {
        manager.targetsalive++;
        mat.SetFloat("_dispell", 0f);
      
    }

    // Update is called once per frame
    void Update()
    {
    if (disolve == true)
        {
            currentdisolve = Mathf.Lerp(currentdisolve, 1, 0.5f * Time.deltaTime);
            mat.SetFloat("_dispell", currentdisolve);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
             Debug.Log("Collided");
            manager.score += pointvalue;
            manager.targetsalive--;
            disolve = true;
              Destroy(gameObject,3.5f);
         
       

        }
    }
   
   
}
