using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    // public float radiusExplosion = 16f;
  //  public respawn pow;
    public powerup_respawn pow;
    // Start is called before the first frame update
      public void Start()
    {
      //  pow = GetComponentInParent<respawn>();
    }

       public  void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<power_Up_State>().canpickup == true)
            {
                other.gameObject.GetComponent<power_Up_State>()._state = power_Up_State.powers_manage.blast;
                //   power_up_state._state = powers_manage.blast;
                // power_up_state.powers_manage.blast;
                // pow.timer();
                pow.timer();
                Destroy(gameObject);
            }
            }
    }



  
}
