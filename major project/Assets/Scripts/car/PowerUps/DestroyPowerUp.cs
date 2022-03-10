using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public float radiusExplosion = 16f;

    //FinbarRespawn spawn;
    // Start is called before the first frame update
    void Start()
    {
      
        //spawn.GetComponentInParent<FinbarRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }
   

     void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<power_Up_State>().canpickup == true)
            {
                other.gameObject.GetComponent<power_Up_State>()._state = power_Up_State.powers_manage.blast;
                //   power_up_state._state = powers_manage.blast;
                // power_up_state.powers_manage.blast;
                Destroy(gameObject);
                //spawn.isSpawned = false;
            }
            }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }
}
