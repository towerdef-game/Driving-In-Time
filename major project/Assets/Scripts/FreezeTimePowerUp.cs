using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTimePowerUp : MonoBehaviour
{
    //private GameObject GameManager;
    //private Timer timer;
    public float pauseTime = 5f;
    public Timer timer;

    private void Start()
    {
        //timer = GameManager.GetComponent<Timer>();
    }
   // void OnCollisionEnter(Collision collision)
   // {
       // if (collision.gameObject.tag == "Player")
        //{
          //  StartCoroutine(PickUp(collision));
       // }
   // }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Player")
            {
                // Explode();
                if (other.gameObject.GetComponent<power_Up_State>().canpickup == true)
                {
                    other.gameObject.GetComponent<power_Up_State>()._state = power_Up_State.powers_manage.slowdown;
                    //   power_up_state._state = powers_manage.blast;
                    // power_up_state.powers_manage.blast;
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator PickUp(Collider player)
    {
     
        GameObject.FindObjectOfType<Timer>().paused = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //GameManager.GetComponent<Timer>().paused = true;
        //timer = GameManager.GetComponent<Timer>();
        // timer.paused = true;
        yield return new WaitForSeconds(pauseTime);
        //GameManager.GetComponent<Timer>().paused = false;
        //timer.paused = false;
        GameObject.FindObjectOfType<Timer>().paused = false;
        Destroy(gameObject);

    }
}
