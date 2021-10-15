using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerUp : MonoBehaviour
{
    public float pauseTime = 5f;

    private void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PickUp(collision));
        }
    }

    IEnumerator PickUp(Collision player)
    {
        GameObject.FindObjectOfType<CarController>();
        ;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(pauseTime);
        GameObject.FindObjectOfType<CarController>();
        Destroy(gameObject);

    }
}
