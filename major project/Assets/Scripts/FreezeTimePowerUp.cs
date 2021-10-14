using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTimePowerUp : MonoBehaviour
{
    private GameObject GameManager;
    private Timer timer;
    public float pauseTime = 5f;
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PickUp(collision));
        }
    }

    IEnumerator PickUp(Collision player)
    {
        //GameManager.GetComponent<Timer>().paused = true;
        timer = GameManager.GetComponent<Timer>();
        timer.paused = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(pauseTime);
        //GameManager.GetComponent<Timer>().paused = false;
        timer.paused = false;
        Destroy(gameObject);

    }
}
