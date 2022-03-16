using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaintMode : MonoBehaviour
{
    public Transform car;
    public static bool gaintMode;
   public static CarController speed;

    void Start()
    {
        speed= GameObject.Find("Car").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit car");
           car.localScale = new Vector3(10, 10, 10);
            gaintMode = true;
            
            GameManager.powerUpTime = 10f;
            Destroy(gameObject);
            speed.speed *= 5;

        }else
        Debug.Log("hit" +collision.gameObject.name);
    }
}
