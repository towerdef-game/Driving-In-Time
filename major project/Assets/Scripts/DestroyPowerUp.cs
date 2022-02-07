using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public float radiusExplosion = 16f;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            }
            }
    }

    public void Explode()
    {

        Collider[] coll = Physics.OverlapSphere(transform.position, radiusExplosion);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<TargetEnemy>())
            //if (coll[i].gameObject.tag == "Target")
            {
                coll[i].gameObject.GetComponent<TargetEnemy>().TakeDamage();
            }
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }
}
