using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class BoostPowerUp : MonoBehaviour
{
    public float pauseTime = 5f;
    //public CarController carController;
    public StudioEventEmitter powerup;
    private void Start()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<power_Up_State>().canpickup == true)
            {
                int shotgun = Random.Range(1, 4);
                powerup.SetParameter("random", shotgun);
                powerup.Play();

                other.gameObject.GetComponent<power_Up_State>()._state = power_Up_State.powers_manage.speedup;
                //   power_up_state._state = powers_manage.blast;
                // power_up_state.powers_manage.blast;
                Destroy(gameObject);
            }
        }
    }


    // void OnCollisionEnter(Collision collision)
    // {
    // if (collision.gameObject.tag == "Player")
    //  {
    //      StartCoroutine(PickUp(collision));
    //}
    /// }

    //  IEnumerator PickUp(Collision player)
    //   {
    //  GameObject.FindObjectOfType<CarController>().speed *= 2;
    //carController.speed *= 2;
    //  GetComponent<MeshRenderer>().enabled = false;
    //  GetComponent<Collider>().enabled = false;
    //    yield return new WaitForSeconds(pauseTime);
    //    GameObject.FindObjectOfType<CarController>().speed /= 2; 
    //carController.speed /= 2;
    //    Destroy(gameObject);

    // }
}
