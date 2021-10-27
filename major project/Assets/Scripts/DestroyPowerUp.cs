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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    public void Explode()
    {

        Collider[] coll = Physics.OverlapSphere(transform.position, radiusExplosion);

        for (int i = 0; i < coll.Length; i++)
        {
           // if (coll[i].gameObject.GetComponent<EnemyExplode>())
            //{
                
           // }
        }
        Destroy(gameObject, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusExplosion);
    }
}
